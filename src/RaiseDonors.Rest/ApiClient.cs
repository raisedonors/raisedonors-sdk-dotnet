using System;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Models;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;
using RaiseDonors.Rest.Realms;
using System.Security.Cryptography;

namespace RaiseDonors.Rest {
    public interface IApiClient {
        Task<RaiseDonorsResponse<AuthTicket>> AuthorizeAsync(string clientKey);

        Task<RaiseDonorsResponse<AuthTicket>> RefreshAccessToken(string clientKey, string refreshToken);
    }
    public class ApiClient : IApiClient {
        private const string _defaultBaseUrl = "https://api.raisedonors.com";
        private readonly string _baseUrl;
        private readonly long? _clientId;
        private readonly string _clientKey;
        private readonly string _clientSecret;
        private readonly long? _organizationId;

        public ReportingRealm Reporting;
        public DonationRealm Donations;

        public ApiClient(string clientKey, string clientSecret, long? clientId, long? organizationId, string baseUrl = _defaultBaseUrl) {
            _baseUrl = baseUrl;
            _clientId = clientId;
            _organizationId = organizationId;
            _clientKey = clientKey;
            _clientSecret = clientSecret;

            if (_clientId.HasValue && _organizationId.HasValue) {
                Reporting = new ReportingRealm(CreateApiToken(), _clientId.Value, _organizationId.Value, _baseUrl);
                Donations = new DonationRealm(CreateApiToken(), _clientId.Value, _organizationId.Value, _baseUrl);
            }
        }

        public async Task<RaiseDonorsResponse<AuthTicket>> AuthorizeAsync(string clientKey) {
            var restClient = new RestClient(_baseUrl);
            var response = new RaiseDonorsResponse<AuthTicket>();

            var request = new RestRequest("oauth/authorize", Method.GET);
            request.AddHeader("Content-Type", "application/json");

            if (_clientId.HasValue) {
                request.AddHeader("X-RaiseDonorsClientID", _clientId.ToString());
            }

            request.AddParameter("client_id", clientKey);
            request.AddParameter("grant_type", "client_credentials");

            var restResponse = await restClient.ExecuteGetTaskAsync(request);

            response.StatusCode = restResponse.StatusCode;
            response.JsonResponse = restResponse.Content;

            if (restResponse.StatusCode != HttpStatusCode.OK) {
                response.ErrorMessage = restResponse.ErrorMessage;
            }
            else {
                response.Data = CreateAuthTicket(restResponse);
            }

            return response;
        }

        public async Task<RaiseDonorsResponse<AuthTicket>> RefreshAccessToken(string clientKey, string refreshToken) {
            var restClient = new RestClient(_baseUrl);
            var response = new RaiseDonorsResponse<AuthTicket>();

            var request = new RestRequest("oauth/token", Method.POST);
            request.AddHeader("Content-Type", "application/json");

            if (_clientId.HasValue) {
                request.AddHeader("X-RaiseDonorsClientID", _clientId.ToString());
            }

            request.AddQueryParameter("client_id", clientKey);
            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", refreshToken);

            var restResponse = await restClient.ExecuteTaskAsync(request);

            response.StatusCode = restResponse.StatusCode;
            response.JsonResponse = restResponse.Content;

            if (restResponse.StatusCode != HttpStatusCode.OK) {
                response.ErrorMessage = restResponse.ErrorMessage;
            }
            else {
                response.Data = CreateAuthTicket(restResponse);
            }

            return response;
        } 

        protected AuthTicket CreateAuthTicket(IRestResponse response) {
            var json = JObject.Parse(response.Content);

            return new AuthTicket {
                AccessToken = json.SelectToken("access_token").ToString(),
                RefreshToken = json.SelectToken("refresh_token").ToString(),
                ExpiresAt = DateTime.UtcNow.AddSeconds(double.Parse(json.SelectToken("expires_in").ToString()))
            };
        }

        protected string CreateApiToken() {
            var md = CalculateMD5Hash(string.Format("{0}:{1}@{2}", _clientKey, _clientSecret, DateTime.UtcNow.ToString("yyyy-MM-dd")));
            return string.Format("{0}:{1}", _clientKey, EncodeTo64(md.ToLower()));
        }

        public string CalculateMD5Hash(string input) {
            var md5 = new MD5CryptoServiceProvider();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++) {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        private string EncodeTo64(string toEncode) {

            var toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            var returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;
        }
    }
}
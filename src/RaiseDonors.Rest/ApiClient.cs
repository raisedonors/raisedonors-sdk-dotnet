using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Models;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;
using RaiseDonors.Rest.Realms;

namespace RaiseDonors.Rest {
    public interface IApiClient {
        Task<RaiseDonorsResponse<AuthTicket>> AuthorizeAsync(string clientKey);

        Task<RaiseDonorsResponse<AuthTicket>> RefreshAccessToken(string clientKey, string refreshToken);
    }
    public class ApiClient : IApiClient {
        private const string _defaultBaseUrl = "https://api.raisedonors.com";
        private readonly string _baseUrl;
        private readonly long? _clientId;
        private readonly long? _organizationId;
        private readonly string _accessToken;

        public ReportingRealm Reporting;

        public ApiClient(string baseUrl = _defaultBaseUrl) : this(null, null, baseUrl) {
        }

        public ApiClient(long clientId, string baseUrl = _defaultBaseUrl) : this(string.Empty, clientId, null, baseUrl) {

        }

        public ApiClient(string accessToken, long? clientId, string baseUrl = _defaultBaseUrl) : this(accessToken, null, null, baseUrl) {

        }

        public ApiClient(string accessToken, long? clientId, long? organizationId, string baseUrl = _defaultBaseUrl) {
            _baseUrl = baseUrl;
            _clientId = clientId;
            _organizationId = organizationId;
            _accessToken = accessToken;

            if (_clientId.HasValue && _organizationId.HasValue) {
                Reporting = new ReportingRealm(_clientId.Value, _accessToken, _organizationId.Value, _baseUrl);
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

        private AuthTicket CreateAuthTicket(IRestResponse response) {
            var json = JObject.Parse(response.Content);

            return new AuthTicket {
                AccessToken = json.SelectToken("access_token").ToString(),
                RefreshToken = json.SelectToken("refresh_token").ToString(),
                ExpiresAt = DateTime.UtcNow.AddSeconds(double.Parse(json.SelectToken("expires_in").ToString()))
            };
        }
    }
}
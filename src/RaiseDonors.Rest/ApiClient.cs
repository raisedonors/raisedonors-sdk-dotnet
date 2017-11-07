using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Models;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;

namespace RaiseDonors.Rest {
    public interface IApiClient {
        Task<RaiseDonorsResponse<AuthTicket>> AuthorizeAsync(string clientID, long clientId);
    }
    public class ApiClient : IApiClient {
        private readonly string _baseUrl;

        public ApiClient(string baseUrl) {
            _baseUrl = baseUrl;
        }
        public async Task<RaiseDonorsResponse<AuthTicket>> AuthorizeAsync(string clientKey, long clientId) {
            var restClient = new RestClient(_baseUrl);
            var response = new RaiseDonorsResponse<AuthTicket>();

            var request = new RestRequest("oauth/authorize", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-RaiseDonorsClientID", clientId.ToString());

            request.AddParameter("client_id", clientKey);
            request.AddParameter("grant_type", "client_credentials");

            var restResponse = await restClient.ExecuteGetTaskAsync(request);

            response.StatusCode = restResponse.StatusCode;
            response.JsonResponse = restResponse.Content;

            if (restResponse.StatusCode != HttpStatusCode.OK) {
                response.ErrorMessage = restResponse.ErrorMessage;
            }
            else {
                var json = JObject.Parse(restResponse.Content);

                var authTicket = new AuthTicket {
                    AccessToken = json.SelectToken("access_token").ToString(),
                    RefreshToken = json.SelectToken("refresh_token").ToString(),
                    ExpiresAt = DateTime.UtcNow.AddSeconds(double.Parse(json.SelectToken("expires_in").ToString()))
                };

                response.Data = authTicket;
            }

            return response;
        }
    }
}
using RaiseDonors.Rest.Models;
using RestSharp;

namespace RaiseDonors.Rest.Extensions {
    public static class RestsharpExtensions {
        public static IRaiseDonorsResponse ToRaiseDonorsResponse(this IRestResponse restResponse) {
            var response = new RaiseDonorsResponse();

            response.StatusCode = restResponse.StatusCode;
            response.JsonResponse = restResponse.Content;

            if (restResponse.StatusCode != System.Net.HttpStatusCode.OK) {
                response.ErrorMessage = restResponse.ErrorMessage;
            }

            return response;
        }

        public static IRaiseDonorsResponse<S> ToRaiseDonorsResponse<S>(this IRestResponse<S> restResponse) where S : new() {
            var response = new RaiseDonorsResponse<S>();

            response.StatusCode = restResponse.StatusCode;
            response.JsonResponse = restResponse.Content;

            if ((int)restResponse.StatusCode >= 300) {
                response.ErrorMessage = restResponse.ErrorMessage;
            }
            else {
                response.Data = restResponse.Data;
            }
            return response;
        }

        public static IRaiseDonorsResponse<S> ToRaiseDonorsResponse<S>(this IRestResponse<S> restResponse, string requestInput) where S : new() {
            var response = restResponse.ToRaiseDonorsResponse();
            response.RequestValue = requestInput;
            return response;
        }
    }
}

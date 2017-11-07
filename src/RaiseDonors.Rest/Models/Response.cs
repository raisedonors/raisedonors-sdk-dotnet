using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace RaiseDonors.Rest.Models {
    public interface IRaiseDonorsResponse {
        string RequestValue { get; set; }
        string JsonResponse { get; set; }
        HttpStatusCode StatusCode { get; set; }
        string ErrorMessage { get; set; }
    }
    public interface IRaiseDonorsResponse<T> : IRaiseDonorsResponse {
        T Data { get; set; }
    }

    public class RaiseDonorsResponse : IRaiseDonorsResponse {
        public string RequestValue { get; set; }

        public string JsonResponse { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class RaiseDonorsResponse<T> : RaiseDonorsResponse, IRaiseDonorsResponse<T> where T : new() {
        public T Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest;

namespace RaiseDonors.Rest.IntegrationTests.Integration {
    public class Base {
        private const string _baseUrl = "http://localhost:63382";

        public Base() {
            ApiClient = new ApiClient(_baseUrl);
        }

        public ApiClient ApiClient { get; set; }
    }
}

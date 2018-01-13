using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace RaiseDonors.Rest.Tests.Integration {
    public class AuthBase {
        internal const string _baseUrl = "http://localhost:63382";
        internal long _clientId = 10;
        internal const string _clientKey = "RaiseDonors";
        internal const string _clientSecret = "e1efa1d66e914840ad7a671822738ba7";
        internal long _organizationId = 2;


        public AuthBase() {
            
        }

        [OneTimeSetUp]
        public virtual async Task Setup() {
            RaiseDonorsClient = new ApiClient(_clientKey, _clientSecret, _clientId, _organizationId, _baseUrl);
        }

        public ApiClient RaiseDonorsClient { get; set; }
    }
}

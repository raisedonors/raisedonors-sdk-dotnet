using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace RaiseDonors.Rest.Tests.Integration {
    public class AuthBase {
        internal const string _baseUrl = "http://dev.api.raisedonors.com";
        internal long _clientId = 0;
        private const string _clientKey = "";
        private long _organizationId = 0;

        public AuthBase() {
            RaiseDonorsClient = new ApiClient(_baseUrl, _clientId);
        }

        [OneTimeSetUp]
        public virtual async Task Setup() {
            var restClient = new ApiClient(_clientId, _baseUrl);
            var authTicket = await restClient.AuthorizeAsync(_clientKey);

            RaiseDonorsClient = new ApiClient(authTicket.Data.AccessToken, _clientId, _organizationId, _baseUrl);
        }

        public ApiClient RaiseDonorsClient { get; set; }
    }
}

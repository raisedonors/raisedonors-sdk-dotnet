using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace RaiseDonors.Rest.IntegrationTests.Integration {
    [TestFixture]
    public class AuthorizeTests : Base {
        private const string _clientKey = "RaiseDonors";
        private long _clientId = 1;

        [OneTimeSetUp]
        public void Setup() {

        }

        [Test]
        public async Task integration_authorize_first_party_key() {
            var response = await ApiClient.AuthorizeAsync(_clientKey, _clientId);

            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
            response.Data.ShouldNotBe(null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace RaiseDonors.Rest.Tests.Integration {
    [TestFixture]
    public class AuthorizeTests : Base {
        private const string _clientKey = "RaiseDonors";


        [OneTimeSetUp]
        public void Setup() {

        }

        [Test]
        public async Task integration_authorize_first_party_key_invalid_user() {
            var restClient = new ApiClient(_clientId, _baseUrl);
            var response = await restClient.AuthorizeAsync(_clientKey);

            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
            response.Data.ShouldNotBe(null);
        }

        [Test]
        public async Task integration_authorize_first_party_key() {
            var restClient = new ApiClient(_clientId, _baseUrl);
            var response = await restClient.AuthorizeAsync(_clientKey);

            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
            response.Data.ShouldNotBe(null);
        }

        [Test]
        public async Task integration_refresh_access_token() {
            var restClient = new ApiClient(_clientId, _baseUrl);
            var authTicket = await restClient.AuthorizeAsync(_clientKey);

            var refreshAuthTicket = await restClient.RefreshAccessToken(_clientKey, authTicket.Data.RefreshToken);

            refreshAuthTicket.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
            refreshAuthTicket.Data.ShouldNotBe(null);
            refreshAuthTicket.Data.RefreshToken.ShouldBe(authTicket.Data.RefreshToken);
        }
    }
}

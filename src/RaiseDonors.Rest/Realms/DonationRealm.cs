using RaiseDonors.Rest.Donations.Sets;

namespace RaiseDonors.Rest.Realms
{
    public class DonationRealm {
        private FundSet _fundSet;
        private readonly long _clientId;
        private readonly string _apiToken;
        private readonly string _clientSecret;
        private readonly long _organizationId;
        private readonly string _baseUrl;

        public DonationRealm(string apiToken, long clientId, long organizationId, string baseUrl = "https://api.raisedonors.com") {
            _clientId = clientId;
            _apiToken = apiToken;
            _organizationId = organizationId;
            _baseUrl = baseUrl;
        }

        public FundSet Funds {
            get {
                if (_fundSet == null) {
                    _fundSet = new FundSet(_apiToken, _clientId, _organizationId, _baseUrl);
                }

                return _fundSet;
            }
        }        
    }
}

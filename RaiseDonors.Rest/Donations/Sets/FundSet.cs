using RaiseDonors.Rest.Sets;
using RaiseDonors.Rest.Donations.Models;

namespace RaiseDonors.Rest.Donations.Sets
{
    public class FundSet : ApiSet<Fund> {
        private const string LIST_URL = "{0}/v1/funds";
        private string _listUrl;
        private string _showUrl;

        public FundSet(string apiToken, long clientId, long organizationId, string baseUrl) : base(clientId, apiToken, organizationId, baseUrl) {
            _listUrl = string.Format(LIST_URL, organizationId);
            _showUrl = _listUrl + "/{0}";
        }
        protected override string ListUrl { get { return _listUrl; } }

        protected override string CreateUrl { get { return _listUrl; } }

        protected override string GetUrl { get { return _showUrl; } }

        protected override string EditUrl { get { return _showUrl; } }

        protected override string GetChildListUrl { get { return _listUrl; } }
    }
}

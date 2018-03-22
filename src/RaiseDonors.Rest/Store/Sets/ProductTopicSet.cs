using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Sets;
using RaiseDonors.Rest.Store.Models;
using RaiseDonors.Rest.Models;

namespace RaiseDonors.Rest.Store.Sets {
    public class ProductTopicSet : ApiSet<ProductTopic> {
        private const string LIST_URL = "{0}/v1/store/topics";
        private const string CREATE_URL = "{0}/v1/store/topics";

        private string _listUrl;
        private string _showUrl;
        private string _createUrl;

        public ProductTopicSet(string apiToken, long clientId, long organizationId, string baseUrl) : base(clientId, apiToken, organizationId, baseUrl) {
            _listUrl = string.Format(LIST_URL, organizationId);
            _showUrl = _listUrl + "/{0}";
            _createUrl = string.Format(CREATE_URL, organizationId);
        }
        protected override string ListUrl { get { return _listUrl; } }

        protected override string CreateUrl { get { return _createUrl; } }

        protected override string GetUrl { get { return _showUrl; } }

        protected override string EditUrl { get { return _showUrl; } }

        protected override string GetChildListUrl { get { return _listUrl; } }

        public async Task<IRaiseDonorsResponse<ProductTopic>> CreateAsync(long productTopicID) {
            return await PostAsync(string.Format(_createUrl, productTopicID));
        }
    }
}

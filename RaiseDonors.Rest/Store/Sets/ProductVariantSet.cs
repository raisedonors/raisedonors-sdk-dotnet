using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Sets;
using RaiseDonors.Rest.Store.Models;
using RaiseDonors.Rest.Models;


namespace RaiseDonors.Rest.Store.Sets {
    public class ProductVariantSet : ApiSet<ProductVariant> {
        private const string LIST_URL = "{0}/v1/store/products";
        private const string CREATE_URL = "{0}/v1/store/products";

        private string _listUrl;
        private string _showUrl;
        private string _createUrl;
        private string _editUrl;

        public ProductVariantSet(string apiToken, long clientId, long organizationId, string baseUrl) : base(clientId, apiToken, organizationId, baseUrl) {
            _listUrl = string.Format(LIST_URL, organizationId) + "/{0}/variants";
            _showUrl = _listUrl + "/{0}/variants/{1}";
            _createUrl = string.Format(CREATE_URL, organizationId) + "/{0}/variants";
            _editUrl = string.Format(LIST_URL, organizationId) + "/{0}/variants";
        }

        protected override string CreateUrl { get { return _createUrl; } }

        protected override string GetChildListUrl { get { return _listUrl; } }

        protected override string GetChildUrl { get { return _showUrl; } }

        protected override string EditUrl { get { return _editUrl; } }



        public async Task<IRaiseDonorsResponse<ProductVariant>> CreateAsync(long productID, ProductVariant entity) {
            return await CreateAsync(entity, string.Format(_createUrl, productID));
        }

        public async Task<IRaiseDonorsResponse<ProductVariant>> UpdateAsync(long productID, long id, ProductVariant entity) {
            _editUrl = string.Format(_editUrl, productID) + "/{0}";
            return await UpdateAsync(entity, id.ToString());
        }
    }
}

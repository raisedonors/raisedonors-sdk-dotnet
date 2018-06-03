using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Store.Sets;

namespace RaiseDonors.Rest.Realms {
    public class StoreRealm {
        private ProductFormatSet _productFormatSet;
        private ProductTopicSet _productTopicSet;
        private ProductVariantSet _productVariantSet;
        private ProductCatalogSet _productCatalogSet;
        private ProductSet _productSet;
        private readonly long _clientId;
        private readonly string _apiToken;
        private readonly string _clientSecret;
        private readonly long _organizationId;
        private readonly string _baseUrl;

        public StoreRealm(string apiToken, long clientId, long organizationId, string baseUrl = "https://api.raisedonors.com") {
            _clientId = clientId;
            _apiToken = apiToken;
            _organizationId = organizationId;
            _baseUrl = baseUrl;
        }

        public ProductFormatSet ProductFormats {
            get {
                if (_productFormatSet == null) {
                    _productFormatSet = new ProductFormatSet(_apiToken, _clientId, _organizationId, _baseUrl);
                }

                return _productFormatSet;
            }
        }

        public ProductTopicSet ProductTopics {
            get {
                if (_productTopicSet == null) {
                    _productTopicSet = new ProductTopicSet(_apiToken, _clientId, _organizationId, _baseUrl);
                }

                return _productTopicSet;
            }
        }

        public ProductVariantSet ProductVariants {
            get {
                if (_productVariantSet == null) {
                    _productVariantSet = new ProductVariantSet(_apiToken, _clientId, _organizationId, _baseUrl);
                }

                return _productVariantSet;
            }
        }

        public ProductSet Products {
            get {
                if (_productSet == null) {
                    _productSet = new ProductSet(_apiToken, _clientId, _organizationId, _baseUrl);
                }

                return _productSet;
            }
        }

        public ProductCatalogSet ProductCatalogs {
            get {
                if (_productCatalogSet == null) {
                    _productCatalogSet = new ProductCatalogSet(_apiToken, _clientId, _organizationId, _baseUrl);
                }

                return _productCatalogSet;
            }
        }
    }
}

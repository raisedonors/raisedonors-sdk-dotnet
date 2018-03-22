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
    }
}

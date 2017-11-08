using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Reports.Sets;

namespace RaiseDonors.Rest.Realms {
    public class ReportingRealm {
        private ReportDefinitionSet _reportDefinitionSet;
        private readonly long _clientId;
        private readonly string _accessToken;
        private readonly long _organizationId;
        private readonly string _baseUrl;

        public ReportingRealm(long clientId, string accessToken, long organizationId, string baseUrl = "https://api.raisedonors.com") {
            _clientId = clientId;
            _accessToken = accessToken;
            _organizationId = organizationId;
            _baseUrl = baseUrl;
        }

        public ReportDefinitionSet ReportDefinitions {
            get {
                if (_reportDefinitionSet == null) {
                    _reportDefinitionSet = new ReportDefinitionSet(_clientId, _accessToken, _organizationId, _baseUrl);
                }

                return _reportDefinitionSet;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Sets;
using RaiseDonors.Rest.Reports.Models;

namespace RaiseDonors.Rest.Reports.Sets {
    public class ReportQueueSet : ApiSet<ReportQueue> {
        private const string LIST_URL = "{0}/v1/reports/queues";
        private const string CREATE_URL = "{0}/v1/reports";
        
        private string _listUrl;
        private string _showUrl;
        private string _createUrl;

        public ReportQueueSet(string apiToken, long clientId, long organizationId, string baseUrl) : base(clientId, apiToken, organizationId, baseUrl) {
            _listUrl = string.Format(LIST_URL, organizationId);
            _showUrl = _listUrl + "/{1}";
            _createUrl = string.Format(CREATE_URL, organizationId);
            _createUrl = _createUrl + "/{0}/queues";
        }
        protected override string ListUrl { get { return _listUrl; } }

        protected override string CreateUrl { get { return _createUrl; } }

        protected override string GetUrl { get { return _showUrl; } }

        protected override string EditUrl { get { return _showUrl; } }

        protected override string GetChildListUrl { get { return _listUrl; } }
    }
}

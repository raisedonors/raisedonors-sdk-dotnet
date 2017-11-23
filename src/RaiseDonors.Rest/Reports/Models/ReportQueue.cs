using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Reports.Enum;

namespace RaiseDonors.Rest.Reports.Models {
    public class ReportQueue {
        public long Id { get; set; }

        public long ReportDefinitionId { get; set; }

        public string ReportName { get; set; }

        public string ReportSql { get; set; }

        public ReportQueueStatus ReportQueueStatus { get; set; }

        public DateTime? CompletedDateTime { get; set; }

        public string ReportExportURL { get; set; }

        public DateTime? NotifedDateTime { get; set; }

        public string NotificationEmails { get; set; }

        public DateTime? DateRequested { get; set; }

        public DateTime? DateToDelete { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastModified { get; set; }
    }
}

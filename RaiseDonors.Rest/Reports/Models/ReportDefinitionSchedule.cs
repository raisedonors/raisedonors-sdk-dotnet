using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest.Reports.Enum;

namespace RaiseDonors.Rest.Reports.Models {
    public class ReportDefinitionSchedule {
        public long Id { get; set; }

        public RecurrenceType RecurrenceType { get; set; }

        public int RecurrenceRepeat { get; set; }

        public int RecurrenceOrdinal { get; set; }

        public string RecurrenceDayOfWeek { get; set; }

        public DateTime? RecurrenceStop { get; set; }

        public string ReportDefinitionScheduleTime { get; set; }

        public string ReportDefinitionScheduleEmails { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastModified { get; set; }
    }
}

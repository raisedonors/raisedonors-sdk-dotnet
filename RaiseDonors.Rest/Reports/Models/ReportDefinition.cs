using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseDonors.Rest.Reports.Models {
    public class ReportDefinition {
        public ReportDefinition() {
            Schedules = new List<ReportDefinitionSchedule>();
        }

        public long Id { get; set; }

        public bool IsPublic { get; set; }

        public string ReportDefinitionName { get; set; }

        public string ReportDefinitionDescription { get; set; }

        public string ConditionsJson { get; set; }

        public string DefinitionSql { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastModified { get; set; }

        public List<ReportDefinitionSchedule> Schedules { get; set; }
    }
}

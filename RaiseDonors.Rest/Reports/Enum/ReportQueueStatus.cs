using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseDonors.Rest.Reports.Enum {
    public enum ReportQueueStatus {
        Queued = 1,
        Processing = 2,
        Complete = 3,
        Failed = 4
    }
}

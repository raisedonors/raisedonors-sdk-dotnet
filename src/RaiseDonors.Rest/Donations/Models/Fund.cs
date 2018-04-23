using System;

namespace RaiseDonors.Rest.Donations.Models
{
    public class Fund {
        public Fund() {
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public short SortOrder { get; set; }
    }
}

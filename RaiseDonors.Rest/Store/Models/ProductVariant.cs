using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseDonors.Rest.Store.Models {
    public class ProductVariant {
        public long ID { get; set; }

        public long ProductID { get; set; }

        public string Name { get; set; }

        public int ProductFormatID { get; set; }

        public string SKU { get; set; }

        public bool IsPublished { get; set; }

        public bool DisplaySKU { get; set; }

        public bool Downloadable { get; set; }

        public string DownloadUrl { get; set; }

        public bool MultipleQuantities { get; set; }

        public decimal? AdditionalCopyCost { get; set; }

        public int? AdditionalCopyMax { get; set; }

        public decimal FairMarketValue { get; set; }

        public decimal? USAMinDonation { get; set; }

        public decimal? UKMinDonation { get; set; }

        public decimal? CanadaMinDonation { get; set; }

        public decimal? InternationalMinDonation { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}

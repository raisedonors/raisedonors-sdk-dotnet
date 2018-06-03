using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseDonors.Rest.Store.Models {
    public class ProductCatalogHomepage {
        public long ID { get; set; }

        public string HeroAdLargeImageUrl { get; set; }

        public string HeroAdSmallImageUrl { get; set; }

        public string HeroAdLink { get; set; }

        public string PageHeadline { get; set; }

        public string PageCopy { get; set; }

        public long? FeaturedProductID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}

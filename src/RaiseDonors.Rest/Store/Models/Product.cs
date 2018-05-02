using System;
using System.Collections.Generic;

namespace RaiseDonors.Rest.Store.Models {
    public class Product {
        public Product() {
            Topics = new List<ProductTopic>();
            RelatedProducts = new List<Product>();
        }

        public long ID { get; set; }

        public string Name { get; set; }

        public string ImageBase64 { get; set; }

        public string Description { get; set; }

        public string DescriptionCropped { get; set; }

        public List<ProductTopic> Topics { get; set; }

        public List<Product> RelatedProducts { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}

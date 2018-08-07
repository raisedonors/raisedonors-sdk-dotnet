using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using RaiseDonors.Rest.Attributes;
using RaiseDonors.Rest.QueryObjects;

namespace RaiseDonors.Rest.Store.QueryObjects {
    public class ProductCatalogSearchQO : BaseQO {

        [QO("topic")]
        public long? TopicID { get; set; }

        [QO("format")]
        public long? Format { get; set; }

        [QO("search")]
        public string SearchText { get; set; }
    }
}
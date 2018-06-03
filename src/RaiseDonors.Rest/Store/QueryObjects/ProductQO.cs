using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using RaiseDonors.Rest.Attributes;
using RaiseDonors.Rest.QueryObjects;

namespace RaiseDonors.Rest.Store.QueryObjects {
    public class ProductQO : BaseQO {

        [QO("includeVariants")]
        public bool IncludeVariants { get; set; }

        [QO("includeTopics")]
        public bool IncludeTopics { get; set; }
    }
}

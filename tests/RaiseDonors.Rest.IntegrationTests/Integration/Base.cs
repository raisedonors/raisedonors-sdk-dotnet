using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaiseDonors.Rest;
using NUnit.Framework;
using Shouldly;

namespace RaiseDonors.Rest.Tests.Integration {
    public class Base {
        internal const string _baseUrl = "http://localhost:63382";
        internal long _clientId = 10;

        public Base() {
            RaiseDonorsClient = new ApiClient(_baseUrl, _clientId);
        }

        public ApiClient RaiseDonorsClient { get; set; }
    }
}

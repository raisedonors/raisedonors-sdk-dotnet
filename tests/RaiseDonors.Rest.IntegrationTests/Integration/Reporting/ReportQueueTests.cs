using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using System;
using RaiseDonors.Rest.Reports.Models;


namespace RaiseDonors.Rest.Tests.Integration.Reporting {
    [TestFixture]
    public class ReportQueueTests : AuthBase {
        [OneTimeSetUp]
        public override async Task Setup() {
            await base.Setup();
        }

        [Test]
        public async Task integration_report_queues_list_get_list() {
            var reports = await RaiseDonorsClient.Reporting.ReportQueues.ListAsync();
            reports.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }
    }
}

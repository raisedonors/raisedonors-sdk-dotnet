using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using System;
using RaiseDonors.Rest.Reports.Models;
using System.Collections.Generic;
using RaiseDonors.Rest.Models;


namespace RaiseDonors.Rest.Tests.Integration.Reporting {
    [TestFixture]
    public class ReportDefinitionTests : AuthBase {
        [OneTimeSetUp]
        public override async Task Setup() {
            await base.Setup();
        }

        [Test]
        public async Task integration_report_definitions_list_get_list() {
            var reports = await RaiseDonorsClient.Reporting.ReportDefinitions.ListAsync();
            reports.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task integration_report_definitions_create_no_schedule() {
            var reportDefinition = new ReportDefinition {
                ConditionsJson = "{\"root\":{\"linkType\":\"All\",\"enabled\":true,\"conditions\":[{\"justAdded\":false,\"typeName\":\"SMPL\",\"enabled\":true,\"operatorID\":\"DateWithinThisYear\",\"expressions\":[{\"kind\":\"Attribute\",\"typeName\":\"ENTATTR\",\"id\":\"Donation.DateCreated\"}],\"blockId\":\"QueryPanel-cond-1\"}]},\"columns\":[{\"caption\":\"Donation Campaign Name\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.CampaignName\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-1\"},{\"caption\":\"Donation Fund Name\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.FundName\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-2\"},{\"caption\":\"Donation Fund Code\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.FundCode\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-3\"},{\"caption\":\"Donation Amount\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.Amount\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-4\"},{\"caption\":\"Donation Donor Name\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.DonorName\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-5\"},{\"caption\":\"Donation Donor Email\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.DonorEmail\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-6\"},{\"caption\":\"Donation Donor Phone\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.DonorPhone\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-7\"}],\"justsorted\":[],\"modelId\":\"b0af23e3-e521-4b33-be2f-07ff87460a9d\",\"modelName\":null}",
                IsPublic = false,
                ReportDefinitionName = "Test Report Definition",
                ReportDefinitionDescription = "This is an integration test report definition description",
                DefinitionSql = "SELECT Donation.CampaignName AS \"Donation Campaign Name\", Donation.FundName AS \"Donation Fund Name\", Donation.FundCode AS \"Donation Fund Code\", Donation.Amount AS \"Donation Amount\", Donation.DonorName AS \"Donation Donor Name\", Donation.DonorEmail AS \"Donation Donor Email\", Donation.DonorPhone AS \"Donation Donor Phone\" FROM reporting.Donation AS Donation WHERE ('2017-01-01' <= Donation.DateCreated AND Donation.DateCreated < '2018-01-01')"
            };

            var returnResult = await RaiseDonorsClient.Reporting.ReportDefinitions.CreateAsync(reportDefinition);
            returnResult.RequestValue.ShouldNotBeNullOrEmpty();
            returnResult.Data.Id.ShouldBeGreaterThan(0);
        }

        [Test]
        public async Task integration_report_definitions_create_with_schedule() {
            var reportDefinition = new ReportDefinition {
                ConditionsJson = "{\"root\":{\"linkType\":\"All\",\"enabled\":true,\"conditions\":[{\"justAdded\":false,\"typeName\":\"SMPL\",\"enabled\":true,\"operatorID\":\"DateWithinThisYear\",\"expressions\":[{\"kind\":\"Attribute\",\"typeName\":\"ENTATTR\",\"id\":\"Donation.DateCreated\"}],\"blockId\":\"QueryPanel-cond-1\"}]},\"columns\":[{\"caption\":\"Donation Campaign Name\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.CampaignName\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-1\"},{\"caption\":\"Donation Fund Name\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.FundName\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-2\"},{\"caption\":\"Donation Fund Code\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.FundCode\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-3\"},{\"caption\":\"Donation Amount\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.Amount\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-4\"},{\"caption\":\"Donation Donor Name\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.DonorName\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-5\"},{\"caption\":\"Donation Donor Email\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.DonorEmail\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-6\"},{\"caption\":\"Donation Donor Phone\",\"sorting\":\"None\",\"sortIndex\":-1,\"expr\":{\"typeName\":\"ENTATTR\",\"id\":\"Donation.DonorPhone\"},\"params\":[],\"blockId\":\"ColumnsPanel-col-7\"}],\"justsorted\":[],\"modelId\":\"b0af23e3-e521-4b33-be2f-07ff87460a9d\",\"modelName\":null}",
                IsPublic = false,
                ReportDefinitionName = "Test Report Definition With Schedule",
                ReportDefinitionDescription = "This is an integration test report definition description with a schedule",
                DefinitionSql = "SELECT Donation.CampaignName AS \"Donation Campaign Name\", Donation.FundName AS \"Donation Fund Name\", Donation.FundCode AS \"Donation Fund Code\", Donation.Amount AS \"Donation Amount\", Donation.DonorName AS \"Donation Donor Name\", Donation.DonorEmail AS \"Donation Donor Email\", Donation.DonorPhone AS \"Donation Donor Phone\" FROM reporting.Donation AS Donation WHERE ('2017-01-01' <= Donation.DateCreated AND Donation.DateCreated < '2018-01-01')"
            };

            reportDefinition.Schedules.Add(new ReportDefinitionSchedule {
                RecurrenceType = Reports.Enum.RecurrenceType.Daily,
                RecurrenceStop = DateTime.UtcNow.AddMonths(4),
                RecurrenceDayOfWeek = "0,3,4",
                ReportDefinitionScheduleTime = "840, 960",
                ReportDefinitionScheduleEmails = "johndoe@email.com,janedoe@email.com",
                RecurrenceOrdinal = 0,
                RecurrenceRepeat = 0,
            });

            var returnResult = await RaiseDonorsClient.Reporting.ReportDefinitions.CreateAsync(reportDefinition);
            returnResult.RequestValue.ShouldNotBeNullOrEmpty();
            returnResult.Data.Id.ShouldBeGreaterThan(0);
        }

        [Test]
        public async Task integration_report_definitions_call_1000_times() {
            var runResults = new List<dynamic>();
            var tasks = new Task<IRaiseDonorsResponse<List<ReportDefinition>>>[15];

            for (int i = 0; i < 15; i++) {
                var rest = new ApiClient(_clientKey, _clientSecret, _clientId, _organizationId, _baseUrl);
                tasks[i] = rest.Reporting.ReportDefinitions.ListAsync();
            }

            Task.WaitAll(tasks);

            foreach (var task in tasks) {
                var data = task.Result;

                runResults.Add(new {
                    data = data.Data,
                    error = data.ErrorMessage,
                    json = data.JsonResponse,
                    request = data.RequestValue
                });
            }
            runResults.ShouldNotBe(null);
        }
    }
}

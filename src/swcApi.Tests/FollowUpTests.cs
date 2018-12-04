using Api.Database.Entity;
using Api.Database.Entity.Crm;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Swc.Service.Crm;
using swcApi.Controllers;
using swcApi.Utils;
using System;
using System.Threading.Tasks;
using Xunit;

namespace swcApi.Tests
{
    public class FollowUpTests
    {
        FollowUpController controller;
        Mock<IFollowUpService> followUpServiceMock;
        public FollowUpTests()
        {
            var options = Options.Create<AppSettings>(new AppSettings());
            var logger = new Mock<ILogger<FollowUpController>>();

            followUpServiceMock = new Mock<IFollowUpService>();

            controller = new FollowUpController(followUpServiceMock.Object, options
                , logger.Object);


        }

        [Fact]
        public void Should_Insert_FollowUp()
        {
            var branch = Builder<BranchMaster>.CreateNew().Build();
            branch.BranchMasterId = branch.Id;

            var mode = Builder<FollowUpMode>.CreateNew().Build();
            mode.BranchMasterId = branch.Id;

            var status = Builder<FollowUpStatus>.CreateNew().Build();
            status.BranchMasterId = branch.Id;


            var contact = Builder<Contact>.CreateNew().Build();
            contact.BranchMasterId = branch.Id;

            var campaign = Builder<Campaign>.CreateNew().Build();
            campaign.BranchMasterId = branch.Id;

            var campaignInfo = Builder<CampaignInfo>.CreateNew()
                .With(c => c.BranchMasterId = branch.Id)
                .With(c => c.ModeId = mode.Id)
                .With(c => c.StatusId = status.Id)
                .With(c => c.CampaignId = campaign.Id)
                .With(c => c.ContactId = contact.Id)
                .Build();


            followUpServiceMock.Setup(service => service.Insert(campaignInfo))
                .Returns(campaignInfo);

            var result = controller.Insert(campaignInfo);

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);

            var campaignResultTask = okResult.Value as CampaignInfo;
            Assert.NotNull(campaignResultTask);
        }


        [Fact]
        public void Should_Duplicate_Throw_FollowUp()
        {
            var branch = Builder<BranchMaster>.CreateNew().Build();
            branch.BranchMasterId = branch.Id;

            var mode = Builder<FollowUpMode>.CreateNew().Build();
            mode.BranchMasterId = branch.Id;

            var status = Builder<FollowUpStatus>.CreateNew().Build();
            status.BranchMasterId = branch.Id;


            var contact = Builder<Contact>.CreateNew().Build();
            contact.BranchMasterId = branch.Id;

            var campaign = Builder<Campaign>.CreateNew().Build();
            campaign.BranchMasterId = branch.Id;

            var campaignInfo = Builder<CampaignInfo>.CreateNew()
                .With(c => c.BranchMasterId = branch.Id)
                .With(c => c.ModeId = mode.Id)
                .With(c => c.StatusId = status.Id)
                .With(c => c.CampaignId = campaign.Id)
                .With(c => c.ContactId = contact.Id)
                .Build();


            followUpServiceMock.Setup(service => service.Insert(campaignInfo))
                .Throws(new System.Exception("Exception on Add"));

            Assert.Throws<Exception>(() => { controller.Insert(campaignInfo); });


        }
    }
}

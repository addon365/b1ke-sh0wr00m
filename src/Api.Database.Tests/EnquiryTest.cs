using Api.Database.Entity;
using Api.Database.Entity.Crm;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using Api.Database.Tests.Utils;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Database.Tests
{
    [Collection("Database collection")]
    public class EnquiryTest : IClassFixture<ContextFactory>
    {
        ContextFactory contextFactory;
        public EnquiryTest(ContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        [Fact]
        public void ShouldInsertEnquiry()
        {
            var context = contextFactory.GetContext();
            var license = Builder<LicenseMaster>.CreateNew().Build();
            var branch = Builder<BranchMaster>.CreateNew().Build();
            context.LicenseMasters.Add(license);
            branch.LicenseId = license.Id;
            context.BranchMasters.Add(branch);
            context.SaveChanges();
            Assert.Equal(branch.Id, context.BranchMasters.Find(branch.Id).Id);
        }
    }
}

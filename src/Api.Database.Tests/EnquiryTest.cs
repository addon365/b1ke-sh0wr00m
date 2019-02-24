using addon365.Database.Entity;
using addon365.Database.Tests.Utils;
using FizzWare.NBuilder;
using Xunit;

namespace addon365.Database.Tests
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

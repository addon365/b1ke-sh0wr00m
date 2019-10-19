using addon365.Database.Entity;
using addon365.Database.Tests.Utils;
using FizzWare.NBuilder;
using Xunit;

namespace addon365.Database.Tests
{
    [Collection("Database collection")]
    public class LicenseTest : IClassFixture<ContextFactory>
    {
        ContextFactory contextFactory;
        public LicenseTest(ContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        [Fact]
        public void MustAddLicense()
        {
            var context = contextFactory.GetContext();
            var license = Builder<LicenseMaster>.CreateNew().Build();
            context.LicenseMasters.Add(license);
            context.SaveChanges();

            Assert.Equal(license.Id, context.LicenseMasters.Find(license.Id).Id);
        }
    }
}

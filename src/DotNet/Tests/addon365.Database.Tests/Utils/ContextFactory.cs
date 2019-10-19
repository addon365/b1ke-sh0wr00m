using addon365.Database.Entity;
using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Enquiries;
using addon365.Database.Entity.Finance;
using addon365.Database.Entity.Inventory.Catalog;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace addon365.Database.Tests.Utils
{
    public class ContextFactory : IDisposable
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog={0};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static string SeedPath = @"..\..\..\..\Api\seed";
        private ApiContext apiContext;

        public ContextFactory()
        {
            Random random = new Random(100);
            int number = Math.Abs(random.Next());
            connectionString = string.Format(connectionString, "testdb" + number);
            var options = new DbContextOptionsBuilder<ApiContext>()
               .UseSqlServer(connectionString)
               .EnableSensitiveDataLogging()
               .Options;

            apiContext = new ApiContext(options);
            apiContext.Database.EnsureCreated();
            apiContext.Database.OpenConnection();

        }

        public ApiContext GetContext()
        {
            return apiContext;
        }

        public static void Seed(ApiContext context)
        {

            if (!context.CatalogItems.Any())
            {
                var types = JsonConvert.DeserializeObject<List<CatalogItem>>(File.ReadAllText(SeedPath + Path.DirectorySeparatorChar + "products.json"));

                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.marketingZones.Any())
            {
                var types = JsonConvert.DeserializeObject<List<MarketingZone>>(File.ReadAllText(SeedPath + Path.DirectorySeparatorChar + "MarketingZones.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.EnquiryStatuses.Any())
            {
                var types = JsonConvert.DeserializeObject<List<EnquiryStatus>>(File.ReadAllText(SeedPath + Path.DirectorySeparatorChar + "EnquiryStatus.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.EnquriyType.Any())
            {
                var types = JsonConvert.DeserializeObject<List<EnquiryType>>(File.ReadAllText(SeedPath + Path.DirectorySeparatorChar + "EnquiryType.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.CatalogBrands.Any())
            {
                var types = JsonConvert.DeserializeObject<List<CatalogBrand>>(File.ReadAllText(SeedPath + Path.DirectorySeparatorChar + "ProductCompanies.json"));
                context.AddRange(types);
                context.SaveChanges();

            }
            if (!context.CatalogTypes.Any())
            {
                var types = JsonConvert.DeserializeObject<List<CatalogType>>(File.ReadAllText(SeedPath + Path.DirectorySeparatorChar + "ProductTypes.json"));
                context.AddRange(types);
                context.SaveChanges();

            }
            if (!context.LicenseMasters.Any())
            {
                var types = JsonConvert.DeserializeObject<List<LicenseMaster>>(File.ReadAllText(SeedPath + Path.DirectorySeparatorChar + "LIcense.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.PaymentModes.Any())
            {
                var types = JsonConvert.DeserializeObject<List<PaymentMode>>(File.ReadAllText(SeedPath + Path.DirectorySeparatorChar + "PaymentMode.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.FinanceCompanies.Any())
            {
                var types = JsonConvert.DeserializeObject<List<FinanceCompany>>(File.ReadAllText(SeedPath + Path.DirectorySeparatorChar + "FinanceCompanys.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.FollowUpModes.Any())
            {
                var types = JsonConvert.DeserializeObject<List<FollowUpMode>>(
                    File.ReadAllText(
                        SeedPath + Path.DirectorySeparatorChar + "FollowUpModes.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.FollowUpStatuses.Any())
            {
                var types = JsonConvert.DeserializeObject<List<FollowUpStatus>>(
                    File.ReadAllText(
                        SeedPath + Path.DirectorySeparatorChar + "FollowUpStatuses.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            SeedEnquiries(context);
        }
        [Conditional("DEBUG")]
        private static void SeedEnquiries(ApiContext context)
        {
            if (!context.Contacts.Any())
            {

                var file = File.ReadAllText(
                        SeedPath + Path.DirectorySeparatorChar + "Contacts.json");
                var types = JsonConvert.DeserializeObject<List<Contact>>(file);
                context.AddRange(types);
                context.SaveChanges();

            }
            if (!context.Enquiries.Any())
            {
                var types = JsonConvert.DeserializeObject<List<Enquiry>>(
                File.ReadAllText(
                    SeedPath + Path.DirectorySeparatorChar + "Enquiries.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.EnquiryItems.Any())
            {
                var types = JsonConvert.DeserializeObject<List<EnquiryCatalogItem>>(
                File.ReadAllText(
                SeedPath + Path.DirectorySeparatorChar + "EnquiryProducts.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            apiContext.Database.EnsureDeleted();
            apiContext.Dispose();
            apiContext = null;
        }
    }
}

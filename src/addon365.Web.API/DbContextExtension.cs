using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using Newtonsoft.Json;
using addon365.Database;
using addon365.Database.Entity.Enquiries;
using addon365.Database.Entity;
using addon365.Database.Entity.Finance;
using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Crm;
using System.Diagnostics;
using addon365.Database.Entity.Report;
using System;
using addon365.Database.Entity.Inventory.Products;
using Microsoft.Extensions.DependencyInjection;
using addon365.Database.Service;
namespace addon365.Web.Api
{
    public static class DbContextExtension
    {

        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();

        }

        public static void EnsureSeeded(this ApiContext context)
        {
            
            if (!context.InquiryReport.Any())
            {
                try
                {
                    var types = JsonConvert.DeserializeObject<List<InquiryReport>>(
                        File.ReadAllText(
                            "seed" + Path.DirectorySeparatorChar + "InquiryReport.json")
                            );
                    context.AddRange(types);
                    context.SaveChanges();
                }
                catch (Exception exception)
                {
                    Console.Write(exception);
                }

            }
            if (!context.BranchMasters.Any())
            {
                var types = JsonConvert.DeserializeObject<List<BranchMaster>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "BranchMaster.json"));

                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "products.json"));
                context.AddRange(products);

                var ProductPropertyMasters = JsonConvert.DeserializeObject<List<ProductPropertyMaster>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "ProductPropertyMasters.json"));
                context.AddRange(ProductPropertyMasters);
                
                foreach(Product p in products)
                {
                    foreach(ProductPropertyMaster pm in ProductPropertyMasters)
                    {
                        ProductPropertiesMap mp = new ProductPropertiesMap();
                        mp.ProductId = p.Id;
                        mp.ProductPropertyMasterId = pm.Id;
                        context.Add(mp);
                    }
                }
                context.SaveChanges();
            }
            if (!context.marketingZones.Any())
            {
                var types = JsonConvert.DeserializeObject<List<MarketingZone>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "MarketingZones.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.EnquiryStatuses.Any())
            {
                var types = JsonConvert.DeserializeObject<List<EnquiryStatus>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "EnquiryStatus.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.EnquriyType.Any())
            {
                var types = JsonConvert.DeserializeObject<List<EnquiryType>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "EnquiryType.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.ProductCompanies.Any())
            {
                var types = JsonConvert.DeserializeObject<List<ProductCompany>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "ProductCompanies.json"));
                context.AddRange(types);
                context.SaveChanges();

            }
            if (!context.ProductTypes.Any())
            {
                var types = JsonConvert.DeserializeObject<List<ProductType>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "ProductTypes.json"));
                context.AddRange(types);
                context.SaveChanges();

            }
            if (!context.LicenseMasters.Any())
            {
                var types = JsonConvert.DeserializeObject<List<LicenseMaster>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "LIcense.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.PaymentModes.Any())
            {
                var types = JsonConvert.DeserializeObject<List<PaymentMode>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "PaymentMode.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.FinanceCompanies.Any())
            {
                var types = JsonConvert.DeserializeObject<List<FinanceCompany>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "FinanceCompanys.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.FollowUpModes.Any())
            {
                var types = JsonConvert.DeserializeObject<List<FollowUpMode>>(
                    File.ReadAllText(
                        "seed" + Path.DirectorySeparatorChar + "FollowUpModes.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.FollowUpStatuses.Any())
            {
                var types = JsonConvert.DeserializeObject<List<FollowUpStatus>>(
                    File.ReadAllText(
                        "seed" + Path.DirectorySeparatorChar + "FollowUpStatuses.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            SeedOnDebug(context);
            if (!context.VoucherTypeMasters.Any())
            {
                var types = JsonConvert.DeserializeObject<List<VoucherTypeMaster>>(
                    File.ReadAllText(
                        "seed" + Path.DirectorySeparatorChar + "VoucherTypeMaster.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.AccountBooks.Any())
            {
                var types = JsonConvert.DeserializeObject<List<AccountBook>>(
            File.ReadAllText(
                "seed" + Path.DirectorySeparatorChar + "AccountBook.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
        }
        [Conditional("DEBUG")]
        private static void SeedOnDebug(ApiContext context)
        {
            if (!context.Contacts.Any())
            {

                var file = File.ReadAllText(
                        "seed" + Path.DirectorySeparatorChar + "Contacts.json");
                var types = JsonConvert.DeserializeObject<List<Contact>>(file);
                context.AddRange(types);
                context.SaveChanges();

            }
            if (!context.Enquiries.Any())
            {
                var types = JsonConvert.DeserializeObject<List<Enquiry>>(
                File.ReadAllText(
                    "seed" + Path.DirectorySeparatorChar + "Enquiries.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.EnquiryProducts.Any())
            {
                var types = JsonConvert.DeserializeObject<List<EnquiryProduct>>(
                File.ReadAllText(
                "seed" + Path.DirectorySeparatorChar + "EnquiryProducts.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.DeviceMasters.Any())
            {
                var types = JsonConvert.DeserializeObject<List<DeviceMaster>>(
                File.ReadAllText(
                    "seed" + Path.DirectorySeparatorChar + "Devices.json")
                    );
                context.AddRange(types);
                context.SaveChanges();
            }

        }
    }

}
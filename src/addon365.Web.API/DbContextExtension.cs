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
using addon365.Database.Entity.Inventory.Catalog;
using Microsoft.Extensions.DependencyInjection;
using addon365.Database.Service;
using addon365.Database.Entity.Permission;

namespace addon365.Web.API
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

            #region CRM Seeds
            //TODO: Need to move CRM Seeds inside this region.
            if (!context.LeadStatusMasters.Any())
            {
                var types = JsonConvert.DeserializeObject<List<LeadStatusMaster>>(
                    File.ReadAllText(
                        "seed" + Path.DirectorySeparatorChar + "LeadStatusMaster.json")
                        );
                context.AddRange(types);
                context.SaveChanges();
            }
            #endregion
            if (!context.InquiryReport.Any())
            {
                var types = JsonConvert.DeserializeObject<List<InquiryReport>>(
                    File.ReadAllText(
                        "seed" + Path.DirectorySeparatorChar + "InquiryReport.json")
                        );
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.BranchMasters.Any())
            {
                var types = JsonConvert.DeserializeObject<List<BranchMaster>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "BranchMaster.json"));

                context.AddRange(types);
                context.SaveChanges();
            }

            if (!context.CatalogItems.Any())
            {
                var products = JsonConvert.DeserializeObject<List<CatalogItem>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "products.json"));
                context.AddRange(products);

                var ProductPropertyMasters = JsonConvert.DeserializeObject<List<CatalogItemPropertyMaster>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "ProductPropertyMasters.json"));
                context.AddRange(ProductPropertyMasters);

                foreach (CatalogItem p in products)
                {
                    foreach (CatalogItemPropertyMaster pm in ProductPropertyMasters)
                    {
                        CatalogItemPropertiesMap mp = new CatalogItemPropertiesMap();
                        mp.CatalogItemId = p.Id;
                        mp.CatalogPropertyMasterId = pm.Id;
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
            if (!context.CatalogItems.Any())
            {
                var types = JsonConvert.DeserializeObject<List<CatalogBrand>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "ProductCompanies.json"));
                context.AddRange(types);
                context.SaveChanges();

            }
            if (!context.CatalogTypes.Any())
            {
                var types = JsonConvert.DeserializeObject<List<CatalogType>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "ProductTypes.json"));
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
            if (!context.LeadSources.Any())
            {
                var file = File.ReadAllText(
                       "seed" + Path.DirectorySeparatorChar + "LeadSource.json");
                var types = JsonConvert.DeserializeObject<List<LeadSource>>(file);
                context.AddRange(types);
            }
            if (!context.StatusMasters.Any())
            {
                var file = File.ReadAllText(
                       "seed" + Path.DirectorySeparatorChar + "StatusMasters.json");
                var types = JsonConvert.DeserializeObject<List<StatusMaster>>(file);
                context.AddRange(types);
            }
            if (!context.RoleGroup.Any())
            {
                var types = JsonConvert.DeserializeObject<List<RoleGroupMaster>>(
                    File.ReadAllText(
                        "seed" + Path.DirectorySeparatorChar + "RoleGroupMaster.json"));
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


            }
            if (!context.Enquiries.Any())
            {
                var types = JsonConvert.DeserializeObject<List<Enquiry>>(
                File.ReadAllText(
                    "seed" + Path.DirectorySeparatorChar + "Enquiries.json"));
                context.AddRange(types);
            }
            if (!context.EnquiryItems.Any())
            {
                var types = JsonConvert.DeserializeObject<List<EnquiryCatalogItem>>(
                File.ReadAllText(
                "seed" + Path.DirectorySeparatorChar + "EnquiryProducts.json"));
                context.AddRange(types);
            }
            if (!context.DeviceMasters.Any())
            {
                var types = JsonConvert.DeserializeObject<List<DeviceMaster>>(
                File.ReadAllText(
                    "seed" + Path.DirectorySeparatorChar + "Devices.json")
                    );
                context.AddRange(types);
            }
            context.SaveChanges();
        }
    }

}
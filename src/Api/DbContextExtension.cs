using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using Api.Database.Entity.Threats;
using Newtonsoft.Json;
using Api.Database;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using Api.Database.Entity;

namespace swcApi
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

            if (!context.Products.Any())
            {
                var types = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "products.json"));
          
                context.AddRange(types);
                context.SaveChanges();
            }
            if (!context.marketingZones.Any())
            {
                var types = JsonConvert.DeserializeObject<List<MarketingZone>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "MarketingZones.json"));
                context.AddRange(types);
                context.SaveChanges();
            }

            //Ensure we have some status
            //if (!context.Status.Any())
            //{
            //    var stati = JsonConvert.DeserializeObject<List<Status>>(File.ReadAllText(@"seed" + Path.DirectorySeparatorChar + "status.json"));
            //    context.AddRange(stati);
            //    context.SaveChanges();

            //}
            //if (!context.Status.Any())
            //{
            //    var stati = JsonConvert.DeserializeObject<List<EnquiryStatus>>(File.ReadAllText(@"seed" + Path.DirectorySeparatorChar + "status.json"));
            //    context.AddRange(stati);
            //    context.SaveChanges();

            //}
            //Ensure we create initial Threat List
            //if (!context.Threats.Any())
            //{
            //    var threats = JsonConvert.DeserializeObject<List<Threat>>(File.ReadAllText(@"seed" + Path.DirectorySeparatorChar + "threats.json"));
            //    context.AddRange(threats);
            //    context.SaveChanges();
            //}
        }
    }

}
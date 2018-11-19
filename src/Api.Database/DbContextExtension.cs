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


namespace Api.Database
{
    public static class DbContextExtension
    {

        public static bool AllMigrationsApplied(this DbContext context)
        {
            //var applied = context.GetService<IHistoryRepository>()
            //    .GetAppliedMigrations()
            //    .Select(m => m.MigrationId);

            //var total = context.GetService<IMigrationsAssembly>()
            //    .Migrations
            //    .Select(m => m.Key);

            //return !total.Except(applied).Any();
            return true;
        }

        public static void EnsureSeeded(this ApiContext context)
        {
        }
    }

}
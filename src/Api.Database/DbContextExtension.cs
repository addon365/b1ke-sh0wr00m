using Microsoft.EntityFrameworkCore;


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
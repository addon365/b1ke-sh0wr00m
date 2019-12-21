using addon365.Chit.DataEntity;
using addon365.Common.DataEntity;
using addon365.Crm.DataEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.Chit.EfContext
{
    public class DatabaseContext : DbContext
    {

        #region Crm
        public DbSet<ContactTable> Contacts { get; set; }
        public DbSet<CustomerTable> Customers { get; set; }

        #endregion
        #region Chit
        public DbSet<ChitSchemeTable> ChitSchemes { get; set; }
        public DbSet<ChitGroupTable> ChitGroups { get; set; }
        public DbSet<ChitSubscriberTable> ChitSubscribers { get; set; }
        public DbSet<ChitSubriberDueTable> ChitSubriberDues { get; set; }

        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=config69;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.HasDefaultSchema(schema: DBGlobals.SchemaName);
       

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            Audit();
            return await base.SaveChangesAsync();
        }

        private void Audit()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntityWithLogFields && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntityWithLogFields)entry.Entity).Created = DateTime.UtcNow;
                }
            ((BaseEntityWithLogFields)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}

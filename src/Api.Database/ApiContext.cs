using System;
using Api.Database.Entity.Threats;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity;

using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        //public ApiContext()
        //{
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=portal;Trusted_Connection=True;MultipleActiveResultSets=True;");
        //}
        public DbSet<Threat> Threats { get; set; }
        public DbSet<ThreatType> Type { get; set; }
        public DbSet<Status> Status { get; set; }

        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<EnquiryType> EnquriyType { get; set; }
        public DbSet<EnquiryStatus> EnquiryStatus { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: DBGlobals.SchemaName);
            modelBuilder.Entity<Threat>().HasIndex(i => i.Referer).IsUnique();
            modelBuilder.Entity<Threat>()
              .Property(p => p.Identifier).HasComputedColumnSql("CONCAT('" + DBGlobals.IdentifierFormat + "',[Id])");
            modelBuilder.Entity<ThreatType>();
            modelBuilder.Entity<Status>();
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
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
            ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}


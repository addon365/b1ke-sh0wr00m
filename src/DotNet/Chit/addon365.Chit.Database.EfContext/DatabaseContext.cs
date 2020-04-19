using addon365.Accounting.DataEntity;
using addon365.Chit.Database.Helper;
using addon365.Chit.DataEntity;
using addon365.Common.DataEntity;
using addon365.Common.DataEntity.Privilage;
using addon365.Crm.DataEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.Chit.Database.EfContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        #region Crm
        public DbSet<ContactTable> Contacts { get; set; }
        public DbSet<CustomerTable> Customers { get; set; }

        #endregion
        #region Chit
        public DbSet<ChitSchemeTable> ChitSchemes { get; set; }
        public DbSet<ChitGroupTable> ChitGroups { get; set; }
        public DbSet<ChitSubscriberTable> ChitSubscribers { get; set; }
        public DbSet<ChitSubscriberDueTable> ChitSubriberDues { get; set; }
        public DbSet<AgentTable> Agents { get; set; }

        #endregion
        #region Accounting
        public DbSet<AccountBookTable> AccountBooks { get; set; }
        public DbSet<AccountGroupTable> AccountGroups { get; set; }
        public DbSet<AccountBookFieldMapTable> AccountBookFieldMaps { get; set; }
        public DbSet<VoucherTypeTable> VoucherTypes { get; set; }
        public DbSet<VoucherTable> Vouchers { get; set; }
        public DbSet<VoucherInfoTable> VoucherInfos { get; set; }
        #endregion
        #region Feature_Privilage
        public DbSet<BusinessPrivilageTable> BusinessPrivilages { get; set; }
        public DbSet<BranchPrivilageTable> BranchPrivilages { get; set; }
        public DbSet<UserRolePrivilageTable> UserRolePrivilages { get; set; }
        public DbSet<UserPrivilageTable> UserPrivilages { get; set; }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer(@"Data Source=LAP-TAMILSELVAN\SQLEXPRESS;Initial Catalog=ChitDataTestSeeding;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
              //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\Database\ChitData.mdf;Trusted_Connection=Yes;");
                
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema(schema: DBGlobals.SchemaName);
       

            base.OnModelCreating(modelBuilder);

            Seeding(modelBuilder);

        }
        private void Seeding(ModelBuilder modelBuilder)
        {
            BusinessBasicData businessBasicData = new BusinessBasicData();

            
            modelBuilder.Entity<ContactTable>().HasData(businessBasicData.lstContact);

            modelBuilder.Entity<AgentTable>().HasData(businessBasicData.lstAgent);

            modelBuilder.Entity<AccountGroupTable>().HasData(businessBasicData.lstAccountGroup);

            modelBuilder.Entity<AccountBookTable>().HasData(businessBasicData.lstAccountBook);

            modelBuilder.Entity<AccountBookFieldMapTable>().HasData(businessBasicData.lstAccountBookFieldMap);

            modelBuilder.Entity<BusinessPrivilageTable>().HasData(businessBasicData.lstBusinessPrivilage);
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

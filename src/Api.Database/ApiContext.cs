using System;
using Api.Database.Entity.Threats;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Api.Database.Entity.Products;
using Api.Database.Entity.User;
using Api.Database.Entity.Finance;
using Api.Database.Entity.Accounts;
using Api.Database.Entity.Employee;
using Api.Database.Entity.Crm;
using Api.Database.Entity.Report;
using Api.Database.Entity.Inventory;

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

        public DbSet<User> Users { get; set; }
        public DbSet<LicenseMaster> LicenseMasters { get; set; }
        public DbSet<BranchMaster> BranchMasters { get; set; }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<ThreatType> Type { get; set; }
        public DbSet<Status> Statuses { get; set; }
      
       
        #region Crm
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MarketingZone> marketingZones { get; set; }
        public DbSet<FollowUpMode> FollowUpModes { get; set; }
        public DbSet<FollowUpStatus> FollowUpStatuses { get; set; }
        public DbSet<CampaignInfo> CampaignInfos { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        #endregion
        #region Enquiry
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<EnquiryType> EnquriyType { get; set; }
        public DbSet<EnquiryStatus> EnquiryStatuses { get; set; }
        public DbSet<EnquiryProduct> EnquiryProducts { get; set; }
        public DbSet<EnquiryExchangeQuotation> EnquiryExchangeQuotations { get; set; }
        public DbSet<EnquiryFinanceQuotation> EnquiryFinanceQuotations { get; set; }
        public DbSet<EnquiryAccessories> EnquiryAccessories { get; set; }
        #endregion
        #region Product
        public DbSet<ProductCompany> ProductCompanies { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ExtraFittingsAccessories> ExtraFittings { get; set; }
        #endregion
        #region Accounts
        public DbSet<PaymentMode> PaymentModes { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherInfo> VouchersInfo { get; set; }
        #endregion
        #region Financing
        public DbSet<FinanceCompany> FinanceCompanies { get; set; }
        #endregion
        #region Employee
        public DbSet<Employee> Employees { get; set; }
        #endregion
        #region Inventory
        public DbSet<InventoryMaster> InventoryMasters { get; set; }
        public DbSet<InventoryInfo> InventoryInfos { get; set; }
        public DbSet<InventoryItemMaster> InventoryItemMasters { get; set; }

        #endregion
        #region Report
        public DbSet<InquiredMonthly> InquiredProducts { get; set; }
        #endregion


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


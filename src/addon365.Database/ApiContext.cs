using addon365.Database.Entity;
using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Chit;
using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Crm.Address;
using addon365.Database.Entity.Employees;
using addon365.Database.Entity.Enquiries;
using addon365.Database.Entity.Finance;
using addon365.Database.Entity.Inventory;
using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Entity.Inventory.Purchases;
using addon365.Database.Entity.Inventory.Sales;
using addon365.Database.Entity.Permission;
using addon365.Database.Entity.Report;
using addon365.Database.Entity.Threats;
using addon365.Database.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.Database
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<LicenseMaster> LicenseMasters { get; set; }
        public DbSet<DeviceMaster> DeviceMasters { get; set; }
        public DbSet<BranchMaster> BranchMasters { get; set; }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<ThreatType> Type { get; set; }
        public DbSet<Status> Statuses { get; set; }

        #region Chit
        public DbSet<ChitSubriberDue> ChitSubscriberDues { get; set; }
        public DbSet<ChitSubscriber> ChitSubscribers { get; set; }
        public DbSet<ChitScheme> ChitSchemes { get; set; }
        #endregion




        #region Crm

        #region Address
        public DbSet<Master> AddressMasters { get; set; }
        public DbSet<StateMaster> States { get; set; }
        public DbSet<DistrictMaster> Districts { get; set; }
        public DbSet<SubDistrictMaster> SubDistricts { get; set; }
        public DbSet<LocalityOrVillageMaster> Localities { get; set; }
        public DbSet<PincodeMaster> Pincodes { get; set; }
        #endregion

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MarketingZone> marketingZones { get; set; }
        public DbSet<FollowUpMode> FollowUpModes { get; set; }
        public DbSet<FollowUpStatus> FollowUpStatuses { get; set; }
        public DbSet<CampaignInfo> CampaignInfos { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<BusinessCustomer> BusinessCustomers { get; set; }
        public DbSet<BusinessContact> BusinessContacts { get; set; }


        public DbSet<LeadStatusHistory> LeadHistory { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
        public DbSet<StatusMaster> StatusMasters { get; set; }
        public DbSet<LeadStatusMaster> LeadStatusMasters { get; set; }
        public DbSet<LeadSource> LeadSources { get; set; }
        #endregion
        #region Enquiry
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<EnquiryType> EnquriyType { get; set; }
        public DbSet<EnquiryStatus> EnquiryStatuses { get; set; }
        public DbSet<EnquiryCatalogItem> EnquiryItems { get; set; }
        public DbSet<EnquiryExchangeQuotation> EnquiryExchangeQuotations { get; set; }
        public DbSet<EnquiryFinanceQuotation> EnquiryFinanceQuotations { get; set; }
        public DbSet<EnquiryAccessories> EnquiryAccessories { get; set; }
        #endregion

        #region Accounts
        public DbSet<PaymentMode> PaymentModes { get; set; }
        public DbSet<AccountBook> AccountBooks { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherInfo> VouchersInfo { get; set; }
        public DbSet<VoucherTypeMaster> VoucherTypeMasters { get; set; }
        #endregion
        #region Financing
        public DbSet<FinanceCompany> FinanceCompanies { get; set; }
        #endregion
        #region Employee
        public DbSet<Employee> Employees { get; set; }
        #endregion
        #region Inventory

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<SaleItemProperty> SaleItemsProperties { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<PurchaseItemPropertyValue> PurchaseItemProperties { get; set; }

        #region Product
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogItemPropertyMaster> CatalogItemPropertyMasters { get; set; }
        public DbSet<CatalogItemPropertiesMap> CatalogItemPropertiesMaps { get; set; }

        #endregion

        #endregion
        #region Report
        public DbSet<InquiryReport> InquiryReport { get; set; }
        #endregion

        #region Permission
        public DbSet<RoleGroupMaster> RoleGroup { get; set; }
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


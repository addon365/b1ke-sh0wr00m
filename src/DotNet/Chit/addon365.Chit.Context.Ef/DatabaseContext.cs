using addon365.Accounts.DataEntity;
using addon365.Chit.DataEntity;
using addon365.Common.DataEntity;
using addon365.Crm.DataEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.Chit.Context.Ef
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
        public DbSet<ChitSubscriberDueTable> ChitSubriberDues { get; set; }
        public DbSet<AgentTable> Agents { get; set; }

        #endregion
        #region Accounts
        public DbSet<AccountBookTable> AccountBooks { get; set; }
        public DbSet<AccountGroupTable> AccountGroups { get; set; }
        public DbSet<AccountBookFieldMapTable> AccountBookFieldMaps { get; set; }
        public DbSet<VoucherTypeTable> VoucherTypes { get; set; }
        public DbSet<VoucherTable> Vouchers { get; set; }
        public DbSet<VoucherInfoTable> VoucherInfos { get; set; }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//#if !Debug
            optionsBuilder.UseSqlServer(@"Data Source=LAP-TAMILSELVAN\SQLEXPRESS;Initial Catalog=ChitData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//#else
//            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\Database\ChitData.mdf;Trusted_Connection=Yes;");
//#endif
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema(schema: DBGlobals.SchemaName);
       

            base.OnModelCreating(modelBuilder);

            var AgentContactNone = new ContactTable {FirstName = "None" };
            modelBuilder.Entity<ContactTable>().HasData(AgentContactNone);

            var AgentNoneRow = new AgentTable {AccessId="0",ContactId=AgentContactNone.KeyId };
            modelBuilder.Entity<AgentTable>().HasData(AgentNoneRow);


            var UnderGroupAsset = new AccountGroupTable { AccountGroupName = "Assets", ProgId = AccountGroupProgs.Assets };
            modelBuilder.Entity<AccountGroupTable>().HasData(UnderGroupAsset);

            var UnderGroupLiabilities = new AccountGroupTable { AccountGroupName = "Liabilities", ProgId = AccountGroupProgs.Liabilities };
            modelBuilder.Entity<AccountGroupTable>().HasData(UnderGroupLiabilities);

            var UnderGroupIncome = new AccountGroupTable { AccountGroupName = "Income", ProgId = AccountGroupProgs.Income };
            modelBuilder.Entity<AccountGroupTable>().HasData(UnderGroupIncome);

            var UnderGroupExpense = new AccountGroupTable { AccountGroupName = "Expense", ProgId = AccountGroupProgs.Expense };
            modelBuilder.Entity<AccountGroupTable>().HasData(UnderGroupExpense);

            var CashInHand = new AccountGroupTable { AccountGroupName = "Cash In Hand", ParentGroupId = UnderGroupAsset.KeyId };
            modelBuilder.Entity<AccountGroupTable>().HasData(CashInHand);

            var CurrentLiabilities = new AccountGroupTable { AccountGroupName = "Current Liabilities", ParentGroupId = UnderGroupLiabilities.KeyId };
            modelBuilder.Entity<AccountGroupTable>().HasData(CurrentLiabilities);

            modelBuilder.Entity<AccountGroupTable>().HasData(
                new AccountGroupTable { AccountGroupName = "Bank Account",ParentGroupId=UnderGroupAsset.KeyId},
                new AccountGroupTable { AccountGroupName = "Loan & Advance(Assets)",ParentGroupId=UnderGroupAsset.KeyId },
                new AccountGroupTable { AccountGroupName = "Inventments", ParentGroupId = UnderGroupAsset.KeyId },
                new AccountGroupTable { AccountGroupName = "Fixed Assets", ParentGroupId = UnderGroupAsset.KeyId },
                new AccountGroupTable { AccountGroupName = "Suspense A/c", ParentGroupId = UnderGroupAsset.KeyId },
                new AccountGroupTable { AccountGroupName = "Unsecured Loans", ParentGroupId = UnderGroupAsset.KeyId },
                new AccountGroupTable { AccountGroupName = "Miscellineous Expenses(Assets)", ParentGroupId = UnderGroupAsset.KeyId },
                new AccountGroupTable { AccountGroupName = "Current Assets", ParentGroupId = UnderGroupAsset.KeyId },
                new AccountGroupTable { AccountGroupName = "Deposits(Assets)", ParentGroupId = UnderGroupAsset.KeyId },
                new AccountGroupTable { AccountGroupName = "Bank OCC", ParentGroupId = UnderGroupLiabilities.KeyId },
                new AccountGroupTable { AccountGroupName = "Loan(Liability)", ParentGroupId = UnderGroupLiabilities.KeyId },
                new AccountGroupTable { AccountGroupName = "Duties & Taxes", ParentGroupId = UnderGroupLiabilities.KeyId },
                new AccountGroupTable { AccountGroupName = "Sundry Creditors", ParentGroupId = UnderGroupLiabilities.KeyId },
                new AccountGroupTable { AccountGroupName = "Sundry Debitors", ParentGroupId = UnderGroupLiabilities.KeyId },
                new AccountGroupTable { AccountGroupName = "Provisions", ParentGroupId = UnderGroupLiabilities.KeyId },
                new AccountGroupTable { AccountGroupName = "Capital Account", ParentGroupId = UnderGroupLiabilities.KeyId },
                new AccountGroupTable { AccountGroupName = "Branch / Divisions", ParentGroupId = UnderGroupLiabilities.KeyId },
                new AccountGroupTable { AccountGroupName = "Direct Incomes", ParentGroupId = UnderGroupIncome.KeyId },
                new AccountGroupTable { AccountGroupName = "InDirect Incomes", ParentGroupId = UnderGroupIncome.KeyId },
                new AccountGroupTable { AccountGroupName = "Provisions", ParentGroupId = UnderGroupIncome.KeyId },
                new AccountGroupTable { AccountGroupName = "Reserves & Surplus", ParentGroupId = UnderGroupIncome.KeyId },
                new AccountGroupTable { AccountGroupName = "SalesAccount", ParentGroupId = UnderGroupIncome.KeyId },
                new AccountGroupTable { AccountGroupName = "Direct Expenses", ParentGroupId = UnderGroupExpense.KeyId },
                new AccountGroupTable { AccountGroupName = "Indirect Expenses", ParentGroupId = UnderGroupExpense.KeyId },
                new AccountGroupTable { AccountGroupName = "Purchase Accounts", ParentGroupId = UnderGroupExpense.KeyId },
                new AccountGroupTable { AccountGroupName = "Ratained Earnings", ParentGroupId = UnderGroupExpense.KeyId });

            var CashBook = new AccountBookTable { KeyId = Guid.NewGuid(), BookName = "Cash",UnderAccountGroupKeyId= CashInHand.KeyId,ProgId=AccountBookProgs.CashBook };
            modelBuilder.Entity<AccountBookTable>().HasData(CashBook);


            var ChitCollection = new AccountBookTable { KeyId = Guid.NewGuid(), BookName = "Chit Collection", UnderAccountGroupKeyId = CurrentLiabilities.KeyId };
            modelBuilder.Entity<AccountBookTable>().HasData(ChitCollection);

            var DueAmountInfoKeyIdMap = new AccountBookFieldMapTable { FieldNameKey = "addon365.Chit.DataEntity.ChitSubscriberDueTable.DueAmountInfoKeyId", AccountBookKeyId = ChitCollection.KeyId };
            modelBuilder.Entity<AccountBookFieldMapTable>().HasData(DueAmountInfoKeyIdMap);

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

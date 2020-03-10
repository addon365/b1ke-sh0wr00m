using addon365.Database.Entity;
using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Chit;
using addon365.Database.Entity.Crm;
using addon365.Database.Tests.Utils;
using FizzWare.NBuilder;
using System;
using System.Linq;
using Xunit;

namespace addon365.Database.Tests
{
    [Collection("Database collection")]
    public class ChitTest : IClassFixture<ContextFactory>
    {
        ContextFactory contextFactory;

        LicenseMaster license;
        BranchMaster branch;
        public ChitTest(ContextFactory contextFactory)
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            this.contextFactory = contextFactory;
            var context = contextFactory.GetContext();
            license = Builder<LicenseMaster>.CreateNew()
                .Build();
            branch = Builder<BranchMaster>.CreateNew()
                .With(b => b.LicenseMasterId = license.Id)
                .Build();
            context.BranchMasters.Add(branch);
            context.SaveChanges();
        }
        [Fact]
        public void ShouldInsertCustomer()
        {
            var context = contextFactory.GetContext();

            var chitCustomer = Builder<Customer>.CreateNew()
                .With(cs => cs.BranchMasterId = null)
                .Build();

            var contact = Builder<Contact>.CreateNew()
                .With(cs => cs.BranchMasterId = null)
                .Build();
            context.Contacts.Add(contact);

            chitCustomer.Contact = contact;
            context.Customers.Add(chitCustomer);
            context.SaveChanges();
            Assert.Equal(chitCustomer.Id,
                context.Customers.Find(chitCustomer.Id).Id);
        }
        [Fact]
        public void ShouldInsertVoucherInfo()
        {
            var context = contextFactory.GetContext();

            var voucherInfo = Builder<VoucherInfo>.CreateNew()
                .With(cs => cs.BranchMasterId = null)
                .Build();

            var voucher = Builder<Voucher>.CreateNew()
                .With(cs => cs.BranchMasterId = null)
                .Build();
            context.Vouchers.Add(voucher);

            voucherInfo.VoucherId = voucher.Id;
            context.VouchersInfo.Add(voucherInfo);
            context.SaveChanges();
            Assert.Equal(voucherInfo.Id,
                context.VouchersInfo.Find(voucherInfo.Id).Id);
        }
        [Fact]
        public void ShouldInsertChit()
        {
            var context = contextFactory.GetContext();



            var chitSubscriber = Builder<ChitSubscriber>.CreateNew()
                .With(cs => cs.BranchMasterId = null)
                .With(c =>
                c.ChitSchema = Builder<ChitScheme>.CreateNew()
                 .With(cs => cs.BranchMasterId = null)
                 .Build())
                .With(c =>
                c.Customer = Builder<Customer>.CreateNew()
                 .With(cs => cs.BranchMasterId = null)
                 .Build())
                .Build();
            var voucherInfo = Builder<VoucherInfo>.CreateNew()
                .With(cs => cs.BranchMasterId = null)

                .Build();
            var voucher = Builder<Voucher>.CreateNew()
                .With(cs => cs.BranchMasterId = null)
                .Build();

            var chitSubscriberDue = Builder<ChitSubriberDue>.CreateNew()
                .With(cs => cs.BranchMasterId = null)
                .With(sub => sub.ChitSubscriber = chitSubscriber)
                .With(sub => sub.Voucher = voucher)
                .Build();

            context.ChitSubscriberDues.Add(chitSubscriberDue);
            context.SaveChanges();
            Guid customerId = chitSubscriberDue.ChitSubscriber.Customer.Id;
            Assert.Equal(customerId,
                context.Customers.Find(customerId).Id
                );
        }
        [Fact]
        public void Should_Insert_Multiple_Due()
        {
            var context = contextFactory.GetContext();

            var chitSubscriber = Builder<ChitSubscriber>.CreateNew()
                .With(c =>
                        c.ChitSchema = Builder<ChitScheme>.CreateNew()
                 .Build())
                .With(c =>
                        c.Customer = Builder<Customer>.CreateNew().Build())
                .Build();

            #region Due Payment 1
            var voucher = Builder<Voucher>.CreateNew().Build();
            var voucherInfo = Builder<VoucherInfo>.CreateNew()
                .With(vi =>
                vi.VoucherId = voucher.Id)
                .Build();
            var chitSubscriberDue = Builder<ChitSubriberDue>.CreateNew()
                .With(sub => sub.ChitSubscriber = chitSubscriber)
                .With(sub => sub.Voucher = voucher)
                .Build();
            #endregion

            #region Due Payment 2
            var voucherInfo2 = Builder<VoucherInfo>.CreateNew()
                .With(vi =>
                vi.VoucherId = voucher.Id)
                .Build();


            var chitSubscriberDue2 = Builder<ChitSubriberDue>.CreateNew()
                .With(sub => sub.ChitSubscriber = chitSubscriber)
                .With(sub => sub.Voucher = voucher)
                .Build();
            #endregion

            context.ChitSubscriberDues.Add(chitSubscriberDue);
            context.ChitSubscriberDues.Add(chitSubscriberDue2);
            context.SaveChanges();
            Guid customerId = chitSubscriberDue.ChitSubscriber.Customer.Id;

            var chitSubriberDues = context.ChitSubscriberDues.Where(sd =>
              sd.ChitSubscriber.Customer.Id == customerId);

            Assert.Equal(2, chitSubriberDues.Count());
        }

        [Fact]
        public void Should_Insert_Due_Existing()
        {
            var context = contextFactory.GetContext();

            var chitSubscriber = Builder<ChitSubscriber>.CreateNew()
                .With(c =>
                c.ChitSchema = Builder<ChitScheme>.CreateNew().Build())
                .With(c =>
                c.Customer = Builder<Customer>.CreateNew().Build())
                .Build();

            #region Save Due Payment 1
            var voucher = Builder<Voucher>.CreateNew().Build();
            var voucherInfo = Builder<VoucherInfo>.CreateNew()
                .With(vi =>
                vi.VoucherId = voucher.Id)
                .Build();
            var chitSubscriberDue = Builder<ChitSubriberDue>.CreateNew()
                .With(sub => sub.ChitSubscriber = chitSubscriber)
                .With(sub => sub.Voucher = voucher)
                .Build();

            context.ChitSubscriberDues.Add(chitSubscriberDue);
            context.SaveChanges();
            #endregion

            #region Due Payment 2
            var voucherInfo2 = Builder<VoucherInfo>.CreateNew()
                .With(vi =>
                vi.VoucherId = voucher.Id)
                .Build();


            var chitSubscriberDue2 = Builder<ChitSubriberDue>.CreateNew()
                .With(sub => sub.ChitSubscriber = chitSubscriber)
                .With(sub => sub.Voucher = voucher)
                .Build();
            context.ChitSubscriberDues.Add(chitSubscriberDue2);
            #endregion

            context.SaveChanges();

            Guid customerId = chitSubscriberDue.ChitSubscriber.Customer.Id;

            var chitSubriberDues = context.ChitSubscriberDues.Where(sd =>
              sd.ChitSubscriber.Customer.Id == customerId);

            Assert.Equal(2, chitSubriberDues.Count());
        }
    }
}

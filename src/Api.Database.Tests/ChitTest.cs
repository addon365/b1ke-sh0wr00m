using Api.Database.Entity;
using Api.Database.Entity.Accounts;
using Api.Database.Entity.Chit;
using Api.Database.Entity.Crm;
using Api.Database.Tests.Utils;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.Database.Tests
{
    [Collection("Database collection")]
    public class ChitTest : IClassFixture<ContextFactory>
    {
        ContextFactory contextFactory;
        public ChitTest(ContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        [Fact]
        public void ShouldInsertCustomer()
        {
            var context = contextFactory.GetContext();
            var license = Builder<LicenseMaster>.CreateNew().Build();
            var branch = Builder<BranchMaster>.CreateNew().Build();
            var chitCustomer = Builder<Customer>.CreateNew().Build();

            context.LicenseMasters.Add(license);
            branch.LicenseId = license.Id;
            context.BranchMasters.Add(branch);


            var contact = Builder<Contact>.CreateNew().Build();
            context.Contacts.Add(contact);

            chitCustomer.Profile = contact;
            context.Customers.Add(chitCustomer);
            context.SaveChanges();
            Assert.Equal(chitCustomer.Id,
                context.Customers.Find(chitCustomer.Id).Id);
        }
        [Fact]
        public void ShouldInsertVoucherInfo()
        {
            var context = contextFactory.GetContext();
            var license = Builder<LicenseMaster>.CreateNew().Build();
            var branch = Builder<BranchMaster>.CreateNew().Build();
            var voucherInfo = Builder<VoucherInfo>.CreateNew().Build();

            context.LicenseMasters.Add(license);
            branch.LicenseId = license.Id;
            context.BranchMasters.Add(branch);


            var voucher = Builder<Voucher>.CreateNew().Build();
            context.Vouchers.Add(voucher);

            voucherInfo.Voucher = voucher;
            context.VouchersInfo.Add(voucherInfo);
            context.SaveChanges();
            Assert.Equal(voucherInfo.Id,
                context.VouchersInfo.Find(voucherInfo.Id).Id);
        }
        [Fact]
        public void ShouldInsertChit()
        {
            var context = contextFactory.GetContext();
            var license = Builder<LicenseMaster>.CreateNew().Build();
            var branch = Builder<BranchMaster>.CreateNew()
                .With(b => b.LicenseId = license.Id)
                .Build();

            context.LicenseMasters.Add(license);
            branch.LicenseId = license.Id;
            context.BranchMasters.Add(branch);


            var chitSubscriber = Builder<ChitSubscriber>.CreateNew()
                .With(c =>
                c.ChitSchema = Builder<ChitSchema>.CreateNew().Build())
                .With(c =>
                c.Customer = Builder<Customer>.CreateNew().Build())
                .Build();
            var voucherInfo = Builder<VoucherInfo>.CreateNew()
                .With(vi =>
                vi.Voucher = Builder<Voucher>.CreateNew().Build())
                .Build();
            var chitSubscriberDue = Builder<ChitSubriberDue>.CreateNew()
                .With(sub => sub.ChitSubscriber = chitSubscriber)
                .With(sub => sub.VoucherInfo = voucherInfo)
                .Build();

            context.ChitSubscriberDues.Add(chitSubscriberDue);
                context.SaveChanges();
            Guid customerId = chitSubscriberDue.ChitSubscriber.Customer.Id;
            Assert.Equal(customerId,
                context.Customers.Find(customerId).Id
                );
        }
    }
}

using Api.Database.Entity.Chit;
using Swc.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Chit;
using Api.Database.Entity.Accounts;
using Swc.Service.Accounts;
using Api.Database.Entity.Crm;

namespace Swc.Service.Chit
{
    public class ChitDueService : BaseService<ChitSubriberDue>, IChitDueService
    {
        public const string VOUCHER_TYPE_NAME = "Chit";
        private IAccountBookService bookService;
        private IVoucherTypeService voucherService;
        public ChitDueService(IUnitOfWork unitOfWork,
            IAccountBookService bookService,
            IVoucherTypeService voucherTypeService) : base(unitOfWork)
        {
            this.bookService = bookService;
            this.voucherService = voucherTypeService;
        }


        public List<ChitSubriberDue> GetList(Guid chitSubriberId)
        {
            var result = Repository
                .GetList(
                predicate: chitDue => chitDue.ChitSubscriber.Id == chitSubriberId,
                include: xt => xt.Include(cdx => cdx.Voucher)
                .ThenInclude(vi => vi.VoucherInfos))
                .Items.ToList();
            return result;
        }
        public string GenerateDueId()
        {
            var lastDue = Repository.Single(orderBy:
                x => x.OrderByDescending(m => Convert.ToInt64(m.DueNo)));
            if (lastDue != null && lastDue.DueNo != null)
            {
                return "" + (Convert.ToInt64(lastDue.DueNo) + 1);
            }
            return 1.ToString();
        }
        public string GenerateSubscribeId()
        {
            var lastSubscription = UnitOfWork.GetRepository<ChitSubscriber>()
                 .Single(orderBy:
                x => x.OrderByDescending(m => Convert.ToInt64(m.SubscribeId)));

            if (lastSubscription != null && lastSubscription.SubscribeId != null)
            {
                return "" + (Convert.ToInt64(lastSubscription.SubscribeId) + 1);
            }

            return 1.ToString();
        }

        public ChitSubriberDue Save(ChitSubscribeDomain domain)
        {
            ChitSubscriber chitSubscriber = null;
            ChitSubriberDue chitSubriberDue = new ChitSubriberDue()
            {
                DueNo = GenerateDueId(),
                Voucher = new Voucher()
                {
                    VoucherDate = DateTime.Now,
                    VoucherTypeId = voucherService.FindByName(VOUCHER_TYPE_NAME).Id,
                }

            };
            if (domain.SubscribeId==Guid.Empty)
            {
                Guid customerId = Guid.Empty;
                if (domain.CustomerId == Guid.Empty)
                {
                    var customer = new Customer()
                    {
                        Profile = new Contact()
                        {
                            FirstName = domain.CustomerName,
                            Address = domain.Address,
                            MobileNumber = domain.MobileNumber
                        }
                    };
                    UnitOfWork.GetRepository<Customer>().Add(customer);
                    customerId = customer.Id;
                }
                else
                {
                    customerId = domain.CustomerId;
                }
                chitSubscriber = new ChitSubscriber()
                {
                    ChitSchemeId = domain.ChitSchemeId,
                    CustomerId = customerId,
                    JoinedDate = DateTime.Now,
                    SubscribeId = GenerateSubscribeId()
                };
               

                chitSubriberDue.ChitSubscriber = chitSubscriber;
            }
            else
            {
                chitSubriberDue.ChitSubscriberId = domain.SubscribeId;
            }

            VoucherInfo[] voucherInfos = new VoucherInfo[2];
            voucherInfos[0] = new VoucherInfo()
            {
                bookId = bookService.FindByName(VOUCHER_TYPE_NAME).Id,
                IsCredit = true,
                VoucherId = chitSubriberDue.Voucher.Id,
                Amount = domain.Amount,
                FieldInfo = domain.FieldInfo

            };
            voucherInfos[1] = new VoucherInfo()
            {
                bookId = bookService.FindByName(VOUCHER_TYPE_NAME).Id,
                IsCredit = false,
                VoucherId = chitSubriberDue.Voucher.Id,
                Amount = domain.Amount,
                FieldInfo = domain.FieldInfo
            };
            Repository.Add(chitSubriberDue);
            UnitOfWork.GetRepository<VoucherInfo>().Add(voucherInfos);
            UnitOfWork.SaveChanges();
            return chitSubriberDue;
        }
        public IList<CustomerDueDomain> FindByCustomerName(string customerName)
        {
            return FindByParam(customerName, false);
        }
        public IList<CustomerDueDomain> FindByMobile(string mobileNumber)
        {
            return FindByParam(mobileNumber, true);
        }
        private IList<CustomerDueDomain> FindByParam(string text,bool isMobile)
        {
           
           
            IList<ChitSubscriber> subscriptions = null;
            if (isMobile)
            {
                subscriptions = this.UnitOfWork.GetRepository<ChitSubscriber>()
                    .GetList(
                     predicate: subs =>
                     subs.Customer.Profile.MobileNumber.CompareTo(text) == 0,
                     include: s => s.Include(t => t.Customer.Profile).Include(t => t.ChitSchema)
                     )
                     .Items;
            }
            else
            {
                subscriptions = this.UnitOfWork.GetRepository<ChitSubscriber>()
                    .GetList(
                     predicate: subs =>
                     subs.Customer.Profile.FirstName.Contains(text),
                     include: s => s.Include(t => t.Customer.Profile).Include(t => t.ChitSchema)
                     )
                     .Items;
            }
            IList<CustomerDueDomain> dueDomains = new List<CustomerDueDomain>();
            foreach (var subscription in subscriptions)
            {
                CustomerDueDomain dueDomain = new CustomerDueDomain();
                var dues = this.Repository.GetList(predicate:
                    chitDue =>
                    chitDue.ChitSubscriberId.CompareTo(subscriptions[0].Id) == 0
                    ).Items;
                dueDomain.SubscriptionId = subscription.SubscribeId;
                dueDomain.Name = subscription.Customer.Profile.FirstName;
                dueDomain.Amount = subscription.ChitSchema.MonthlyAmount;
                dueDomain.PaidAmount = dues.Count * subscription.ChitSchema.MonthlyAmount;
                var totalAmount = subscription.ChitSchema.MonthlyAmount *
                    subscription.ChitSchema.TotalMonths;
                dueDomain.BalanceAmount = totalAmount - dueDomain.PaidAmount;
                dueDomains.Add(dueDomain);
            }


            return dueDomains;
        }
    }
}

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
        public void FindSubscriptionByMobile(string mobileNumber)
        {
            var result = this.Repository
                 .GetList(
                 predicate: chitDue =>
                 chitDue.ChitSubscriber.Customer.Profile.MobileNumber.CompareTo(mobileNumber) == 0,
                 include: xt => xt.Include(cdx => cdx.Voucher)
                 .ThenInclude(vi => vi.VoucherInfos))
                 .Items.ToList();

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
            if (domain.SubscribeId == null)
            {
                chitSubscriber = new ChitSubscriber()
                {
                    ChitSchemeId = domain.ChitSchemeId,
                    Customer = new Api.Database.Entity.Crm.Customer()
                    {
                        Profile = new Api.Database.Entity.Crm.Contact()
                        {
                            Name = domain.CustomerName,
                            Address = domain.Address,
                            MobileNumber = domain.MobileNumber
                        }
                    },
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
    }
}

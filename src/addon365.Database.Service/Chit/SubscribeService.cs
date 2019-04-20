using addon365.Database.Entity.Chit;
using addon365.Database.Service.Base;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
using addon365.Domain.Entity.Chit;
using System;
using addon365.Database.Entity.Accounts;
using addon365.Database.Service.Accounts;
using System.Linq;
using addon365.Database;
using addon365.Domain.Entity.Chit.Reports;
using System.Collections.Generic;
using addon365.Database.Entity.Crm;
using addon365.IService.Chit;
using addon365.IService.Accounts;

namespace addon365.Database.Service.Chit
{
    public class SubscribeService : BaseService<ChitSubscriber>, ISubscribeService
    {
        private IUnitOfWork _unitOfWork;
        IVoucherTypeService _voucherTypeService;
        IAccountBookService bookService;
        public SubscribeService(IUnitOfWork<ApiContext> unitOfWork,
             IAccountBookService bookService,
            IVoucherTypeService voucherTypeService)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            this.bookService = bookService;
            this._voucherTypeService = voucherTypeService;
        }
        public ChitSubscriber FindBySubscriptionId(string id)
        {
            var list = _unitOfWork.GetRepository<ChitSubscriber>()
                .GetList(predicate:
                subscriber =>
                subscriber.SubscribeId.CompareTo(id) == 0,
                include: s => s.Include(x => x.Customer)
                .ThenInclude(x => x.Profile)
                .Include(x => x.ChitSchema))
                .Items;
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public ChitSubscriber Save(ChitSubscribeDomain subscriptionDomain)
        {
            return null;
        }
        public string CloseSubscription(string id, double amount)
        {
            try
            {
                ChitSubscriber chitSubscriber = FindBySubscriptionId(id);
                Voucher voucher = new Voucher
                {
                    VoucherDate = new DateTime(),

                };

                var bookId = bookService.FindByName(ChitDueService.VOUCHER_TYPE_NAME).Id;

                VoucherInfo[] voucherInfos = new VoucherInfo[2];
                voucherInfos[0] = new VoucherInfo()
                {
                    bookId = bookId,
                    IsCredit = false,
                    VoucherId = voucher.Id,
                    Amount = amount,
                };
                voucherInfos[1] = new VoucherInfo()
                {
                    bookId = bookId,
                    IsCredit = true,
                    VoucherId = voucher.Id,
                    Amount = amount
                };
                voucher.VoucherTypeId = _voucherTypeService
                    .FindByName(VoucherTypeMasterEnum.Sales.ToString()).Id;
                voucher.VoucherTypeMaster = null;
                chitSubscriber.ClosedVoucherId = voucher.Id;
                Repository.Update(chitSubscriber);
                UnitOfWork.GetRepository<VoucherInfo>().Add(voucherInfos);
                UnitOfWork.GetRepository<Voucher>().Add(voucher);

                UnitOfWork.SaveChanges();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return null;
        }
        IList<ChitSubscriber> FetchByCondition(Guid schemeId, Guid customerId)
        {
            if (schemeId != Guid.Empty && customerId != Guid.Empty)
            {
                return _unitOfWork.GetRepository<ChitSubscriber>()
                .GetList(
                include: s => s.Include(x => x.Customer)
                .ThenInclude(c => c.Profile)
                .Include(sc => sc.ChitSchema),
                predicate: s => s.Customer.Id == customerId
                && s.ChitSchema.Id == schemeId
                ).Items;
            }
            else if (schemeId != Guid.Empty)
            {
                return _unitOfWork.GetRepository<ChitSubscriber>()
                .GetList(
                include: s => s.Include(x => x.Customer)
                .ThenInclude(c => c.Profile)
                .Include(sc => sc.ChitSchema),
                predicate: s => s.ChitSchema.Id == schemeId
                ).Items;
            }
            else if (customerId != Guid.Empty)
            {
                return _unitOfWork.GetRepository<ChitSubscriber>()
                .GetList(
                include: s => s.Include(x => x.Customer)
                .ThenInclude(c => c.Profile)
                .Include(sc => sc.ChitSchema),
                predicate: s => s.Customer.Id == customerId
                ).Items;
            }
            return _unitOfWork.GetRepository<ChitSubscriber>()
                .GetList(
                include: s => s.Include(x => x.Customer)
                .ThenInclude(c => c.Profile)
                .Include(sc => sc.ChitSchema)

                ).Items; ;
        }
        public IList<SubscriberReportDomain> FetchReport(Guid schemeId,
            Guid customerId)
        {
            IList<ChitSubscriber> list = FetchByCondition(schemeId, customerId);
            
            var groupedResult = list.GroupBy(s => s.SubscribeId);


            var subscriptionReport = new List<SubscriberReportDomain>();
            foreach (var item in groupedResult.ToArray())
            {
                string key = item.Key;
                var totalPaidAmount = item.Sum(s => s.ChitSchema.MonthlyAmount);
                var totalPaidMonths = item.Count();
                var firstChitSub = item.First();
                var monthlyAmount = firstChitSub.ChitSchema.MonthlyAmount;
                var totalMonths = firstChitSub.ChitSchema.TotalMonths;
                
                var pendingAmount = (totalPaidMonths * monthlyAmount) - totalPaidAmount;
                var domainObject = new SubscriberReportDomain
                {
                    CustomerName = firstChitSub.Customer.Profile.FirstName,
                    IsClosed = firstChitSub.ClosedVoucherId != Guid.Empty,
                    MonthlyAmount = monthlyAmount,
                    PaidMonth = totalPaidMonths,
                    PendingAmount = pendingAmount,
                    SchemeName = firstChitSub.ChitSchema.SchemaName,
                    SubscriptionDate = firstChitSub.JoinedDate,
                    SubscriptionId = firstChitSub.SubscribeId

                };
                subscriptionReport.Add(domainObject);
            }
            return subscriptionReport;
        }

        public IList<Customer> FindAllCustomers()
        {
            return UnitOfWork.GetRepository<Customer>()
                .GetList(
                include: c => c.Include(x => x.Profile))
                .Items;
        }
    }
}

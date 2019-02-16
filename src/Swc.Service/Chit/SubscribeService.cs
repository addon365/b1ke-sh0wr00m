using Api.Database.Entity.Chit;
using Swc.Service.Base;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Chit;
using System;
using Api.Database.Entity.Accounts;
using Swc.Service.Accounts;
using System.Linq;
using Api.Database;

namespace Swc.Service.Chit
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

    }
}

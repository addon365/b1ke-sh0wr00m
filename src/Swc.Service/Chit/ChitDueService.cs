using Api.Database.Entity.Chit;
using Swc.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
namespace Swc.Service.Chit
{
    public class ChitDueService : BaseService<ChitSubriberDue>,
        IChitDueService
    {
        public ChitDueService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<ChitSubriberDue> GetList(Guid chitSubriberId)
        {
            var result= this.Repository
                .GetList(
                predicate: chitDue => chitDue.ChitSubscriber.Id == chitSubriberId,
                include: xt => xt.Include(cdx => cdx.VoucherInfo)
                .ThenInclude(vi => vi.Voucher))
                .Items.ToList();
            foreach(ChitSubriberDue chitSubscriber in result)
            {
                chitSubscriber.VoucherInfo.Voucher.VoucherInfos = null;
            }
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
    }
}

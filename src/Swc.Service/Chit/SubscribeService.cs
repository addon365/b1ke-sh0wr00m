using Api.Database.Entity.Chit;
using Swc.Service.Base;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Chit;
using System;

namespace Swc.Service.Chit
{
    public class SubscribeService : BaseService<ChitSubscriber>,ISubscribeService
    {
        private IUnitOfWork _unitOfWork;

        public SubscribeService(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}

using Api.Database.Entity.Chit;
using Swc.Service.Base;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
namespace Swc.Service.Chit
{
    public class SubscribeService : BaseService<ChitSubscriber>, ISubscribeService
    {
        public SubscribeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
        public ChitSubscriber findBySubscriptionId(string id)
        {
            var list = Repository
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
    }
}

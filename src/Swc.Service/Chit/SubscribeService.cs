using Api.Database.Entity.Chit;
using Swc.Service.Base;
using Threenine.Data;

namespace Swc.Service.Chit
{
    public class SubscribeService : BaseService<ChitSubscriber>, ISubscribeService
    {
        public SubscribeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}

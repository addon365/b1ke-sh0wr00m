using Api.Database.Entity.Chit;
using Api.Domain.Chit;
using Swc.Service.Base;

namespace Swc.Service.Chit
{
    public interface ISubscribeService:IBaseService<ChitSubscriber>
    {
        ChitSubscriber FindBySubscriptionId(string id);
    }
}

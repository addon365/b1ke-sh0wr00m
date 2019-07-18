using addon365.Database.Entity.Crm.Address;
using addon365.Database.Service.Base;
using addon365.IService.Crm.Address;
using Threenine.Data;

namespace addon365.Database.Service.Crm.Address
{
    public class StateService
        : BaseService<StateMaster>, IStateService
    {
        public StateService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}

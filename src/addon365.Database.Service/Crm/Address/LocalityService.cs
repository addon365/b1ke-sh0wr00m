using addon365.Database.Entity.Crm.Address;
using addon365.Database.Service.Base;
using addon365.IService.Crm.Address;
using Threenine.Data;

namespace addon365.Database.Service.Crm.Address
{
    public class LocalityService
        : BaseService<LocalityOrVillageMaster>, ILocalityService
    {
        public LocalityService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}

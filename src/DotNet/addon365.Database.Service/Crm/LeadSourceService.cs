using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using Threenine.Data;

namespace addon365.Database.Service.Crm
{
    public class LeadSourceService : BaseService<LeadSource>,
        ILeadSourceService
    {
        public LeadSourceService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

    }
}

using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using Threenine.Data;

namespace addon365.Database.Service.Crm
{
    public class LeadStatusService : BaseService<LeadStatusMaster>
   , ILeadStatusService
    {
        public LeadStatusService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public LeadStatusMaster FindByName(string name)
        {
            var items=Repository.GetList(predicate: x => x.Name.CompareTo(name) == 0)
                .Items;
            if (items.Count == 0)
                return null;
            return items[0];
        }
        
    }
}

using addon365.Database.Entity.Crm;
using addon365.IService.Base;

namespace addon365.IService.Crm
{

    public interface ILeadStatusService : IBaseService<LeadStatusMaster>
    {
        LeadStatusMaster FindByName(string name);
    }
}

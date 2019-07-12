using addon365.Database.Entity.Crm;
using addon365.Domain.Entity.Crm;
using addon365.IService.Base;
using System.Collections.Generic;

namespace addon365.IService.Crm
{
    public interface ILeadService : IBaseService<Lead>
    {
        Lead FindByMobile(string mobileNumber, string landline);
        List<LeadViewModel> FindLeads();
    }
}

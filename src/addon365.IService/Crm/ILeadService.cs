using addon365.Database.Entity.Crm;
using addon365.IService.Base;

namespace addon365.IService.Crm
{
    public interface ILeadService : IBaseService<Lead>
    {
        Lead FindByMobile(string mobileNumber, string landline);
    }
}

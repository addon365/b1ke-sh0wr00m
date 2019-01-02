using Api.Database.Entity.Accounts;

namespace Swc.Service.Accounts
{
    public interface IVoucherTypeService
    {
        VoucherTypeMaster FindByName(string name);
    }
}

using Api.Database.Entity.Accounts;
using System.Collections.Generic;

namespace Swc.Service.Accounts
{
    public interface IVoucherTypeService
    {
        VoucherTypeMaster FindByName(string name);
        ICollection<VoucherTypeService> Save(ICollection<VoucherTypeService> typeServices);
    }
}

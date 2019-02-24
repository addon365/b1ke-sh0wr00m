using addon365.Database.Entity.Accounts;
using System.Collections.Generic;

namespace addon365.Database.Service.Accounts
{
    public interface IVoucherTypeService
    {
        VoucherTypeMaster FindByName(string name);
        ICollection<VoucherTypeService> Save(ICollection<VoucherTypeService> typeServices);
    }
}

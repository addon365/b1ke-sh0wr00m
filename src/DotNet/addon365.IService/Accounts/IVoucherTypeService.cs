using addon365.Database.Entity.Accounts;
using System.Collections.Generic;

namespace addon365.IService.Accounts
{
    public interface IVoucherTypeService
    {
        VoucherTypeMaster FindByName(string name);
        ICollection<VoucherTypeMaster> Save(ICollection<VoucherTypeMaster> typeServices);
    }
}

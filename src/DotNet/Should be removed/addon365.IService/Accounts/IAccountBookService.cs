using addon365.Database.Entity.Accounts;
using addon365.IService.Base;

namespace addon365.IService.Accounts
{
    public interface IAccountBookService : IBaseService<AccountBook>
    {
        AccountBook FindByName(string name);
    }
}

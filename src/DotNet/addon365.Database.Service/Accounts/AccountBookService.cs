
using addon365.Database.Entity.Accounts;
using addon365.Database.Service.Base;
using addon365.IService.Accounts;
using Threenine.Data;

namespace addon365.Database.Service.Accounts
{
    public class AccountBookService : BaseService<AccountBook>, IAccountBookService
    {
        public AccountBookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public AccountBook FindByName(string name)
        {
            return Repository.Single(
                predicate: ab => ab.BookName.CompareTo(name) == 0);
        }
    }
}

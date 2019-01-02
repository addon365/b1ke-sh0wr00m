using Api.Database.Entity.Accounts;
using Swc.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Threenine.Data;

namespace Swc.Service.Accounts
{
    public class AccountBookService : BaseService<AccountBook>,IAccountBookService
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

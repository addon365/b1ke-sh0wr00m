using addon365.Database.Entity.Accounts;
using addon365.Database.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Service.Accounts
{
    public interface IAccountBookService:IBaseService<AccountBook>
    {
        AccountBook FindByName(string name);
    }
}

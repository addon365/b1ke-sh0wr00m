using Api.Database.Entity.Accounts;
using Swc.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swc.Service.Accounts
{
    public interface IAccountBookService:IBaseService<AccountBook>
    {
        AccountBook FindByName(string name);
    }
}

using Api.Database.Entity;
using Api.Database.Entity.Accounts;
using System;
using System.Collections.Generic;

namespace Swc.Service.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T Save(T obj);
        T Find(Guid id);
        IEnumerable<T> FindAll();
        T Update(Guid id,T obj);
    }
}

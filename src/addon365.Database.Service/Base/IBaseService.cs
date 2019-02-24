using addon365.Database.Entity;
using addon365.Database.Entity.Accounts;
using System;
using System.Collections.Generic;

namespace addon365.Database.Service.Base
{
    public interface IBaseService<T> where T : BaseEntityWithLogFields
    {
        T Save(T obj);
        T Find(Guid id);
        IEnumerable<T> FindAll();
        T Update(Guid id,T obj);
    }
}

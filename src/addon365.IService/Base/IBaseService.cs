using addon365.Database.Entity;
using addon365.Database.Entity.Accounts;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;

namespace addon365.IService.Base
{
    public interface IBaseService<T> where T : BaseEntityWithLogFields
    {
        IList<T> Save(IList<T> obj);
        T Save(T obj);
        T Find(Guid id);
        IEnumerable<T> FindAll();
        T Update(Guid id, T obj);

        IEnumerable<T> FindByPredicate(Func<T, bool> predicate = null);

    }
}

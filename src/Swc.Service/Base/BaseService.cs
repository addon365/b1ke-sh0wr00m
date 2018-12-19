using Api.Database.Entity;
using System;
using System.Collections.Generic;
using Threenine.Data;

namespace Swc.Service.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        IRepository<T> _repository;
        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<T>();
        }
        public IUnitOfWork UnitOfWork { get; private set; }

        public T Find(Guid id)
        {
            IList<T> items = _repository.GetList(
                predicate: i => i.Id == id).Items;
            if (items.Count == 0)
                return null;
            return items[0];
        }

        public IEnumerable<T> FindAll()
        {
            return _repository.GetList().Items;
        }

        public T Save(T obj)
        {
            _repository.Add(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }

        public T Update(Guid id,T obj)
        {
            _repository.Update(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }
    }
}

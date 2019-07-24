using addon365.Database.Entity;
using addon365.IService.Base;
using System;
using System.Collections.Generic;
using Threenine.Data;

namespace addon365.Database.Service.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntityWithLogFields
    {
        IRepository<T> _repository;
        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<T>();
        }
        public IUnitOfWork UnitOfWork { get; private set; }

        public virtual T Find(Guid id)
        {
            IList<T> items = _repository.GetList(
                predicate: i => i.Id == id).Items;
            if (items.Count == 0)
                return null;
            return items[0];
        }
        public virtual IEnumerable<T> FindByPredicate(Func<T, bool> predicate)
        {
            return _repository.GetList(predicate: item => predicate(item)).Items;
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _repository.GetList().Items;
        }
        public virtual T Save(T obj)
        {
            _repository.Add(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }
        public virtual IList<T> Save(IList<T> obj)
        {
            _repository.Add(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }
        public virtual ICollection<T> Save(ICollection<T> collObj)
        {
            _repository.Add(collObj);
            UnitOfWork.SaveChanges();
            return collObj;
        }

        public virtual T Update(Guid id, T obj)
        {
            _repository.Update(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }
        public IRepository<T> Repository
        {
            get
            {
                return _repository;
            }
        }
    }
}

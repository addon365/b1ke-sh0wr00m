using System;

namespace addon365.Common.IDataService
{
    public interface ICrudDataService<T>
    {
        void Insert(T domainModel);
        void Update(T domainModel);
        void Delete(Guid KeyId);
        void Get(Guid KeyId);
        void GetAll();
       
    }
}

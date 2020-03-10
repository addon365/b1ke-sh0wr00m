using System;

namespace addon365.Common.DataService
{
    public interface ICrudDataService<T>
    {
        void Insert(T domainModel);
        void Update(T domainModel);
        void Delete(Guid keyId);
        T Get(Guid keyId);
        T Get(string accessId);
        
        void GetAll();
       
    }
}

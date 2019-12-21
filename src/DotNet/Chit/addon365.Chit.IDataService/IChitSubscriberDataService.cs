using addon365.Chit.DomainEntity;
using System;

namespace addon365.Chit.IDataService
{
    public interface IChitSubscriberDataService
    {
        void Insert(ChitSubscriberModel chitSubscriberModel);
        void Update(ChitSubscriberModel chitSubscriberModel);
        void Delete(Guid KeyId);
        void Get(Guid KeyId);
        void GetAll();
        ChitSubscriberMasterModel GetMasterData(); 
    }
}

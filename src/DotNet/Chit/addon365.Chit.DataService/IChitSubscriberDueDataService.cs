using addon365.Chit.DomainEntity;
using System;

namespace addon365.Chit.DataService
{
    public interface IChitSubscriberDueDataService
    {
        void Insert(ChitSubscriberDueModel chitSubscriberModel);
        void Update(ChitSubscriberDueModel chitSubscriberModel);
        void Delete(Guid KeyId);
        ChitSubscriberDueModel Get(Guid KeyId);
        ChitSubscriberDueModel Get(string AccessId);
        ChitDueSubscriberDetailModel GetSubscriberDetail(string AccessId);
        void GetAll();
        ChitSubscriberDueScreenModel GetMasterData(); 
    }
}

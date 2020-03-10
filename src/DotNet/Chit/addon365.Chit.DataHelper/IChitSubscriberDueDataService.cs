using addon365.Chit.DomainEntity;
using System;

namespace addon365.Chit.DataHelper
{
    public interface IChitSubscriberDueDataService
    {
        void Insert(ChitSubscriberDueModel chitSubscriberModel);
        void Update(ChitSubscriberDueModel chitSubscriberModel);
        void Delete(Guid KeyId);
        void Get(Guid KeyId);
        void GetAll();
        ChitSubscriberDueScreenModel GetMasterData(); 
    }
}

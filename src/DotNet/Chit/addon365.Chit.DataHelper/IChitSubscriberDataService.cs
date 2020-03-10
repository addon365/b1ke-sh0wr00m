using addon365.Chit.DomainEntity;
using System;

namespace addon365.Chit.DataHelper
{
    public interface IChitSubscriberDataService
    {
        void Insert(ChitSubscriberModel chitSubscriberModel);
        void Update(ChitSubscriberModel chitSubscriberModel);
        void Delete(Guid keyId);
        ChitSubscriberModel Get(Guid keyId);
        void GetAll();
        ChitSubscriberScreenModel GetMasterData();
        ChitGroupModel FindGroup(string accessId);
        AgentModel FindAgent(string accessId);
    }
}

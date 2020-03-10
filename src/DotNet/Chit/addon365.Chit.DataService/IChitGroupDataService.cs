using addon365.Chit.DomainEntity;
using addon365.Common.DataService;
using System;

namespace addon365.Chit.DataService
{
    public interface IChitGroupDataService:ICrudDataService<ChitGroupModel>
    {
        ChitGroupMasterModel GetMasterData();
    }
}

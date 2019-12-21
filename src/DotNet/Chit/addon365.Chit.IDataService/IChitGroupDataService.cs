using addon365.Chit.DomainEntity;
using addon365.Common.IDataService;
using System;

namespace addon365.Chit.IDataService
{
    public interface IChitGroupDataService:ICrudDataService<ChitGroupModel>
    {
        ChitGroupMasterModel GetMasterData();
    }
}

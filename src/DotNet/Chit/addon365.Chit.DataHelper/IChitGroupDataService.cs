using addon365.Chit.DomainEntity;
using addon365.Common.DataHelper;
using System;

namespace addon365.Chit.DataHelper
{
    public interface IChitGroupDataService:ICrudDataService<ChitGroupModel>
    {
        ChitGroupMasterModel GetMasterData();
    }
}

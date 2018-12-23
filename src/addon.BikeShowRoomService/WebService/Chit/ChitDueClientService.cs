using addon.BikeShowRoomService.BaseService;
using Api.Database.Entity.Chit;
using Swc.Service.Base;
using Swc.Service.Chit;
using Threenine.Data;

namespace addon.BikeShowRoomService.WebService.Chit
{
    public class ChitDueClientService : BaseClientService<ChitSubriberDue>
         , IChitDueService
    {
        public override string getUrl()
        {
            return "ChitDue";
        }
    }
}

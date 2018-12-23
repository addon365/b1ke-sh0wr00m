using addon.BikeShowRoomService.BaseService;
using Api.Database.Entity.Chit;
using Swc.Service.Chit;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon.BikeShowRoomService.WebService.Chit
{
    public class SubsriberService : BaseClientService<ChitSubscriber>, ISubscribeService
    {
        public override string getUrl()
        {
            return "Subscribe";
        }
    }
}

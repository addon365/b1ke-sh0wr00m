using System;
using System.Collections.Generic;
using System.Net;
using addon.BikeShowRoomService.BaseService;
using Api.Database.Entity.Chit;
using Newtonsoft.Json;
using Swc.Service.Base;
using Swc.Service.Chit;
using Threenine.Data;

namespace addon.BikeShowRoomService.WebService.Chit
{
    public class ChitDueClientService : BaseClientService<ChitSubriberDue>
         , IChitDueService
    {
        public List<ChitSubriberDue> GetList(Guid chitSubriberId)
        {
            string url = getUrl() + "/subscriber/" + chitSubriberId.ToString();
            var response = _httpClient.GetAsync(url)
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert
                .DeserializeObject<List<ChitSubriberDue>>(result);
            }
            else
            {
                var web = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                Exception ex = JsonConvert.DeserializeObject<Exception>(web);
                if (ex != null)
                    throw ex;
            }
            return null;
        }

        private int List<T>(string result)
        {
            throw new NotImplementedException();
        }

        public override string getUrl()
        {
            return "ChitDue";
        }

        public string GenerateDueId()
        {
            throw new NotImplementedException();
        }

        public string GenerateSubscribeId()
        {
            throw new NotImplementedException();
        }
    }
}

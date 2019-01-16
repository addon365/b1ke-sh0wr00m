using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using addon.BikeShowRoomService.BaseService;
using Api.Database.Entity.Chit;
using Api.Domain.Chit;
using Newtonsoft.Json;
using Swc.Service.Chit;

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

        public override string getUrl()
        {
            return "ChitDue";
        }

        public ChitSubriberDue Save(ChitSubscribeDomain domain)
        {
            var response = _httpClient.PostAsync(getUrl(),
                new StringContent(
                    JsonConvert.SerializeObject(domain), Encoding.UTF8, "application/json"))
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert.DeserializeObject<ChitSubriberDue>(result);
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
    }
}

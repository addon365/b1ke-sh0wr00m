using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using addon365.WebClient.Service.BaseService;
using addon365.Database.Entity.Chit;
using addon365.Domain.Entity.Chit;
using Newtonsoft.Json;
using addon365.Database.Service.Chit;

namespace addon365.WebClient.Service.WebService.Chit
{
    public class ChitDueClientService : BaseClientService<ChitSubriberDue>
         , IChitDueService
    {
        public IList<CustomerDueDomain> FindByCustomerName(string customerName)
        {
            string url = getUrl() + "/subscriber/customerName/" + customerName;
            var response = _httpClient.GetAsync(url)
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert
                .DeserializeObject<List<CustomerDueDomain>>(result);
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

        public IList<CustomerDueDomain> FindByMobile(string mobileNumber)
        {
            string url = getUrl() + "/subscriber/mobile/" + mobileNumber;
            var response = _httpClient.GetAsync(url)
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert
                .DeserializeObject<List<CustomerDueDomain>>(result);
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

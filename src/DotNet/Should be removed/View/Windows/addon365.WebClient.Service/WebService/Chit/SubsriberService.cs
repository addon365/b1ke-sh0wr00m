using addon365.WebClient.Service.BaseService;
using addon365.Database.Entity.Chit;
using addon365.Database.Entity.Crm;
using addon365.Domain.Entity.Chit.Reports;
using Newtonsoft.Json;
using addon365.Database.Service.Chit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using addon365.IService.Chit;

namespace addon365.WebClient.Service.WebService.Chit
{
    public class SubsriberService : BaseClientService<ChitSubscriber>, ISubscribeService
    {
        public string CloseSubscription(string id, double amount)
        {
            string url = getUrl() + "/close/" + id;

            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(new StringContent("amount"), amount + "");
            var response = _httpClient.PutAsync(url, content)
                    .GetAwaiter()
                    .GetResult();
            if (response.IsSuccessStatusCode)
                return null;
            else
                return response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
        }

        public IList<SubscriberReportDomain> FetchReport(Guid schemeId, Guid customerId)
        {
            string url = getUrl() + "/fetchReport/"+ schemeId + "/"+ customerId;
            var response = _httpClient.GetAsync(url)
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert.DeserializeObject<List<SubscriberReportDomain>>(result);
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
            return new List<SubscriberReportDomain>();
        }

        public ChitSubscriber FindBySubscriptionId(string id)
        {
            string url = getUrl() + "?subscriptionId=" + id;
            var response = _httpClient.GetAsync(url)
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert.DeserializeObject<ChitSubscriber>(result);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
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
            return "Subscribe";
        }

        public IList<Customer> FindAllCustomers()
        {
            string url = getUrl() + "/customers";
            var response = _httpClient.GetAsync(url)
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert.DeserializeObject<List<Customer>>(result);
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
            return new List<Customer>();
        }
    }
}

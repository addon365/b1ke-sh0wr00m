using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using addon365.Database.Entity.Crm;
using Newtonsoft.Json;
using addon365.Database.Service;
using addon365.Database.Service.Crm;

namespace addon365.WebClient.Service.WebService
{
    public class FollowUpService : IFollowUpService
    {
        private IDictionary<Guid, FollowUpMode> dictFollowUpMode;
        private IDictionary<Guid, FollowUpStatus> dictFollowUpStatus;
        private readonly HttpClient _httpClient;
        public FollowUpService()
        {
            _httpClient = WebDataClient.Client;
        }

        public IEnumerable<CampaignInfo> GetCampaingInfos(string contactId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("followup/campaign/" + contactId)
              .Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                 .GetAwaiter()
                                 .GetResult();

                return JsonConvert.DeserializeObject<IList<CampaignInfo>>(json);
            }
            return null;
        }

        public Contact GetContact(string contactId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("followup/contact/" + contactId)
              .Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                 .GetAwaiter()
                                 .GetResult();

                return JsonConvert.DeserializeObject<Contact>(json);
            }
            return null;
        }

        public IEnumerable<FollowUpStatus> GetFollowUpStatuses()
        {
            if (dictFollowUpStatus == null)
            {
                dictFollowUpStatus = new Dictionary<Guid, FollowUpStatus>();
                HttpResponseMessage response = _httpClient.GetAsync("followup/followupstatuses")
                .Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                     .GetAwaiter()
                                     .GetResult();

                    IEnumerable<FollowUpStatus> followUpStatuses = JsonConvert.DeserializeObject<IList<FollowUpStatus>>(json);
                    foreach (FollowUpStatus followUpStatus in followUpStatuses)
                    {
                        dictFollowUpStatus.Add(followUpStatus.Id, followUpStatus);
                    }

                    return followUpStatuses;
                }
                return null;
            }
            return dictFollowUpStatus.Values;
        }

        public IEnumerable<FollowUpMode> GetFollowUpModes()
        {
            if (dictFollowUpMode == null)
            {
                dictFollowUpMode = new Dictionary<Guid, FollowUpMode>();

                HttpResponseMessage response = _httpClient.GetAsync("followup/followupmodes")
                .Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                     .GetAwaiter()
                                     .GetResult();

                    IEnumerable<FollowUpMode> followUpModes = JsonConvert.DeserializeObject<IList<FollowUpMode>>(json);
                    foreach (FollowUpMode followUpMode in followUpModes)
                    {
                        dictFollowUpMode.Add(followUpMode.Id, followUpMode);
                    }
                    return followUpModes;
                }
                return null;
            }

            return dictFollowUpMode.Values;
        }

        public CampaignInfo Insert(CampaignInfo campaignInfo)
        {

            var response = _httpClient.PostAsync("followup",
                new StringContent(JsonConvert.SerializeObject(campaignInfo),
                Encoding.UTF8, "application/json"))
                .GetAwaiter()
                .GetResult();
            var result = response.Content.ReadAsStringAsync()
                           .ConfigureAwait(true)
                           .GetAwaiter()
                           .GetResult();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CampaignInfo>(result);
            }
            ErrorDetails errorDetails = JsonConvert.DeserializeObject<ErrorDetails>(result);
            throw new Exception(errorDetails.Message);

        }
        public FollowUpStatus GetFollowUpStatus(Guid guid)
        {
            if (dictFollowUpStatus == null)
                GetFollowUpStatuses();
            return dictFollowUpStatus[guid];
        }

        public FollowUpMode GetFollowUpMode(Guid guid)
        {
            if (dictFollowUpMode == null)
                GetFollowUpModes();
            return dictFollowUpMode[guid];
        }
    }
}

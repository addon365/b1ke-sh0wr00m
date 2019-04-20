using addon365.Database.Entity.Crm;
using Newtonsoft.Json;
using addon365.Database.Service.Crm;
using System;
using System.Collections.Generic;
using System.Net.Http;
using addon365.IService.Crm;

namespace addon365.WebClient.Service.WebService
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService()
        {
            _httpClient = WebDataClient.Client;
        }
        public IEnumerable<Contact> GetContacts()
        {
            HttpResponseMessage response = _httpClient.GetAsync("contact").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                 .GetAwaiter()
                                 .GetResult();

                return JsonConvert.DeserializeObject<IList<Contact>>(json);
            }
            return null;
        }
    }
}

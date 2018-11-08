using Api.Database.Entity.Crm;
using Newtonsoft.Json;
using Swc.Service.Crm;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace addon.BikeShowRoomService.WebService
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

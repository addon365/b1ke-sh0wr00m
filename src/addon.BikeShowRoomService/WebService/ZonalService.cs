using Api.Database.Entity;
using Newtonsoft.Json;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace addon.BikeShowRoomService.WebService
{
   public class ZonalService:IZonalService
    {
        private static HttpClient _httpClient;

        public ZonalService()
        {
            _httpClient = WebDataClient.Client;
        }
        public IEnumerable<MarketingZone> GetAllActive()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Zonal").Result;
            IEnumerable<MarketingZone> marketingZones = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                marketingZones = JsonConvert.DeserializeObject<IEnumerable<MarketingZone>>(json);



            }

            return marketingZones;
        }
        public string Insert(MarketingZone marketingZone)
        {
            string json = JsonConvert.SerializeObject(marketingZone, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var stringContent = new StringContent(JsonConvert.SerializeObject(marketingZone), Encoding.UTF8, "application/json");
            var httpResponce = _httpClient.PostAsync("Zonal", byteContent);


            Console.WriteLine(httpResponce);
            return null;
        }
        public MarketingZone GetReferer(string identifier)
        {
            throw new NotImplementedException();
        }
        public void Delete(MarketingZone marketingZone)
        {
            string json = JsonConvert.SerializeObject(marketingZone, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var stringContent = new StringContent(JsonConvert.SerializeObject(marketingZone), Encoding.UTF8, "application/json");
            var httpResponce = _httpClient.PostAsync("api/Zonal/Delete", byteContent);
        }
    }
}

using addon365.Database.Entity.Enquiries;
using Newtonsoft.Json;
using addon365.Database.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace addon365.WebClient.Service.WebService
{
   public class EnquiryTypeService:IEnquiryTypeService
    {
        private static HttpClient _httpClient;

        public EnquiryTypeService()
        {
            _httpClient = WebDataClient.Client;
        }
        public IEnumerable<EnquiryType> GetAllEnquiryType()
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/EnquiryType").Result;
            IEnumerable<EnquiryType> enquiryTypes = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                enquiryTypes = JsonConvert.DeserializeObject<IEnumerable<EnquiryType>>(json);



            }

            return enquiryTypes;
        }
        public int Insert(EnquiryType enquiryType)
        {
            string json = JsonConvert.SerializeObject(enquiryType, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var stringContent = new StringContent(JsonConvert.SerializeObject(enquiryType), Encoding.UTF8, "application/json");
            var httpResponce = _httpClient.PostAsync("api/EnquiryType", byteContent);


            Console.WriteLine(httpResponce);
            return 1;
        }
        public EnquiryType GetEnquiryType(int programmerId)
        {
            throw new NotImplementedException();
        }
        public void Delete(EnquiryType enquiryType)
        {
            string json = JsonConvert.SerializeObject(enquiryType, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var stringContent = new StringContent(JsonConvert.SerializeObject(enquiryType), Encoding.UTF8, "application/json");
            var httpResponce = _httpClient.PostAsync("api/EnquiryType/Delete", byteContent);
        }
    }
}

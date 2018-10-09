using System;
using System.Collections.Generic;
using System.Linq;
using Api.Database.Entity.Threats;
using Api.Domain.Enquiries;
using Threenine.Data;
using AutoMapper;
using Api.Database.Entity.Enquiries;
using Swc.Service;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace addon.BikeShowRoomService.WebService
{
    public class EnquiriesService : IEnquiriesService
    {

        private readonly HttpClient _httpClient;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";

        public EnquiriesService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = _httpClient.PostAsync("api/user/authenticate",null).ConfigureAwait(true)
            //                    .GetAwaiter()
            //                    .GetResult();
            //byte[] tokenAsByArray = response.Content.ReadAsByteArrayAsync().Result;
            //var header = new AuthenticationHeaderValue("Bearer", Convert.ToBase64String(tokenAsByArray));
            //_httpClient.DefaultRequestHeaders.Authorization = header;
        }
        public IEnumerable<Enquiry> GetAllActive()
        {

            HttpResponseMessage response = _httpClient.GetAsync("api/Enquiries").Result;
            IEnumerable<Enquiry> enquiries = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                enquiries = JsonConvert.DeserializeObject<IEnumerable<Enquiry>>(json);



            }

            return enquiries;
        }


        public async Task<string> Insert(InsertEnquiryModel insertenquiry)
        {
            try { 

            var response = await _httpClient.PostAsync("api/Enquiries", new StringContent(JsonConvert.SerializeObject(insertenquiry), Encoding.UTF8, "application/json"));
            //await Task.Delay(10000);
            
            return response.Content.ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }
       
        public Enquiries GetEnquiries(string identifier)
        {
            return null;
        }

        public InitilizeEnquiry GetInitilizeEnquiries()
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Enquiries").Result;
            InitilizeEnquiry enquiries = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                enquiries = JsonConvert.DeserializeObject<InitilizeEnquiry>(json);



            }

            return enquiries;
        }
    }
}

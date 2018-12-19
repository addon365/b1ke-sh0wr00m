using System;
using System.Collections.Generic;
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
       

        public EnquiriesService()
        {
            _httpClient = WebDataClient.Client;
        }
        public Threenine.Data.Paging.IPaginate<Enquiry> GetAllActive(Api.Domain.Paging.PagingParams pagingParams)
        {

            HttpResponseMessage response = _httpClient.GetAsync("Enquiries?"+ "PageNumber="+pagingParams.PageNumber+ "&PageSize="+pagingParams.PageSize).Result;
            Threenine.Data.Paging.IPaginate<Enquiry> enquiries = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                enquiries = JsonConvert.DeserializeObject<Threenine.Data.Paging.Paginate<Enquiry>>(json);

                string j = json;

            }

            return enquiries;
        }


        public async Task<string> Insert(InsertEnquiryModel insertenquiry)
        {
            try { 

            var response = await _httpClient.PostAsync("Enquiries", new StringContent(JsonConvert.SerializeObject(insertenquiry), Encoding.UTF8, "application/json"));
            //await Task.Delay(10000);
            
            return response.Content.ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }
       
        public InsertEnquiryModel GetEnquiries(string identifier)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Enquiries/"+identifier).Result;
            InsertEnquiryModel enquiries = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                enquiries = JsonConvert.DeserializeObject<InsertEnquiryModel>(json);



            }

            return enquiries;
        }
        public MultiEnquiryModel GetMultiEnquiries(string identifier)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Enquiries/Multi/" + identifier).Result;
            MultiEnquiryModel enquiries = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                enquiries = JsonConvert.DeserializeObject<MultiEnquiryModel>(json);



            }

            return enquiries;
        }

        public InitilizeEnquiry GetInitilizeEnquiries()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Enquiries/InitilizeEnquiries").Result;
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

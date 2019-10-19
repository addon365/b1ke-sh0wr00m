
using addon365.Database.Entity.Enquiries;
using addon365.Database.Service;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System;
using addon365.IService;

namespace addon365.WebClient.Service.WebService
{
    public class BookingService : IBookingService
    {

        private readonly HttpClient _httpClient;
     

        public BookingService()
        {
            _httpClient = WebDataClient.Client;
        }
       

      


        public async Task Insert(Enquiry insertBooking)
        {

            
           

                var response = await _httpClient.PostAsync("Booking", new StringContent(JsonConvert.SerializeObject(insertBooking), Encoding.UTF8, "application/json"));
              if(response.StatusCode==HttpStatusCode.OK)
               {
                    await response.Content.ReadAsStringAsync();
                }
              else
            {
                var web= await response.Content.ReadAsStringAsync();
                Exception ex = JsonConvert.DeserializeObject<Exception>(web);
        
                if (ex != null)
                    throw ex;
            }

             
                
           

        }
        public Threenine.Data.Paging.IPaginate<Enquiry> GetAllBooked(addon365.Domain.Entity.Paging.PagingParams pagingParams)
        {

            HttpResponseMessage response = _httpClient.GetAsync("Booking?" + "PageNumber=" + pagingParams.PageNumber + "&PageSize=" + pagingParams.PageSize).Result;
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
        public Enquiry GetBooked(string identifier)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Enquiries/Booked/Get/" + identifier).Result;
            Enquiry enquiries = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                enquiries = JsonConvert.DeserializeObject<Enquiry>(json);

                return enquiries;

            }

            throw new Exception("Request Failed");


        }

    }
}

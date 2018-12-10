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
using Swc.Service.Sales;
using Api.Domain.Sales;
using Api.Domain.Booking;
using System.Net;

namespace addon.BikeShowRoomService.WebService
{
    public class BookingService : IBookingService
    {

        private readonly HttpClient _httpClient;
     

        public BookingService()
        {
            _httpClient = WebDataClient.Client;
        }
       

      


        public async Task Insert(InsertBooking insertBooking)
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
    }
}

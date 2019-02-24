using System;
using System.Collections.Generic;
using System.Linq;
using addon365.Database.Entity.Threats;
using addon365.Domain.Entity.Enquiries;
using Threenine.Data;
using AutoMapper;
using addon365.Database.Entity.Enquiries;
using addon365.Database.Service;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using addon365.Database.Service.Sales;
using addon365.Domain.Entity.Sales;
using addon365.Database.Entity.Inventory.Sales;

namespace addon365.WebClient.Service.WebService
{
    public class SalesService : ISalesService
    {

        private readonly HttpClient _httpClient;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";

        public SalesService()
        {
            _httpClient = WebDataClient.Client;
        }
       

      

        public InitilizeSales GetInitilizeSales()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Sales/InitilizeSales").Result;
            InitilizeSales enquiries = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                enquiries = JsonConvert.DeserializeObject<InitilizeSales>(json);



            }

            return enquiries;
        }
        public async Task<string> Insert(Sale Model)
        {

            try
            {

                var response = await _httpClient.PostAsync("Sales", new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json"));
              if(!response.IsSuccessStatusCode)
               {
                    string str= await response.Content.ReadAsStringAsync();
                }
                return response.Content.ToString();
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}

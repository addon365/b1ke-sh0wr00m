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

namespace addon.BikeShowRoomService.WebService
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
        public async Task<string> Insert(InsertSalesModel insertSales)
        {

            try
            {

                var response = await _httpClient.PostAsync("Sales", new StringContent(JsonConvert.SerializeObject(insertSales), Encoding.UTF8, "application/json"));
      
                return response.Content.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}

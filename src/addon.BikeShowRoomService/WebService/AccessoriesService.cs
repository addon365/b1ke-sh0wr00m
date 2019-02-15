using Api.Database.Entity.Inventory.Products;
using Newtonsoft.Json;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace addon.BikeShowRoomService.WebService
{
    public class AccessoriesService : IAccessoriesService
    {
        private static HttpClient _httpClient;

        public AccessoriesService()
        {
            _httpClient = WebDataClient.Client;
        }

        public void DeleteAccessories(Guid ProductId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Accessories/Delete/" + ProductId).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

            }
        }

        public IEnumerable<ExtraFittingsAccessories> GetAccessories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExtraFittingsAccessories> GetAccessories(Guid ProductId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Accessories/"+ProductId).Result;
            IEnumerable<ExtraFittingsAccessories> accessories = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                accessories = JsonConvert.DeserializeObject<IEnumerable<ExtraFittingsAccessories>>(json);

               

            }

            return accessories;
        }

        public string InsertAccessories(IEnumerable<ExtraFittingsAccessories> extrafittings)
        {
            IEnumerable<ExtraFittingsAccessories> lst = new List<ExtraFittingsAccessories>();
           
            string str = JsonConvert.SerializeObject(extrafittings);
            var response = _httpClient.PostAsync("api/Accessories/add", new StringContent(str, Encoding.UTF8, "application/json"));




            return null;
        }
        public string UpdateAccessories(IEnumerable<ExtraFittingsAccessories> extrafittings)
        {
            IEnumerable<ExtraFittingsAccessories> lst = new List<ExtraFittingsAccessories>();

            string str = JsonConvert.SerializeObject(extrafittings);
            var response = _httpClient.PostAsync("api/Accessories/update", new StringContent(str, Encoding.UTF8, "application/json"));




            return null;
        }
    }
}

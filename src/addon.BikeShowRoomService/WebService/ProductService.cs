using Api.Database.Entity.Products;
using Newtonsoft.Json;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace addon.BikeShowRoomService.WebService
{
    public class ProductService : IProductService
    {
        private static HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:61780/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public IEnumerable<Product> GetAllActive()
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Product").Result;
            IEnumerable<Product> products = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);



            }

            return products;
        }
        public string Insert(Product product)
        {
            string json = JsonConvert.SerializeObject(product, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var httpResponce = _httpClient.PostAsync("api/Product", byteContent);


            Console.WriteLine(httpResponce);
            return null;
        }
        public Product GetProduct(string identifier)
        {
            throw new NotImplementedException();
        }


    }
}

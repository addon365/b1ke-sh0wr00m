using Api.Database.Entity.Products;
using Newtonsoft.Json;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Net;
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
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://swcapi20181010045554.azurewebsites.net/");
           
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public IEnumerable<ProductCompany> GetCompanies()
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Product/Companies").Result;
            IEnumerable<ProductCompany> companies = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                companies = JsonConvert.DeserializeObject<IEnumerable<ProductCompany>>(json);


                
            }

            return companies;
        }
        public IEnumerable<ProductType> GetTypes()
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Product/Types").Result;
            IEnumerable<ProductType> types = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                types = JsonConvert.DeserializeObject<IEnumerable<ProductType>>(json);



            }

            return types;
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
        public IEnumerable<Product> GetProductByType(int ProgrammerId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Product/"+ ProgrammerId).Result;
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


            //Console.WriteLine(httpResponce);
            return null;
        }
        public string InsertProductType(ProductType producttype)
        {
            string json = JsonConvert.SerializeObject(producttype, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var stringContent = new StringContent(JsonConvert.SerializeObject(producttype), Encoding.UTF8, "application/json");
            var httpResponce = _httpClient.PostAsync("api/Product", byteContent);


            //Console.WriteLine(httpResponce);
            return null;
        }
        public Product GetProduct(string identifier)
        {
            throw new NotImplementedException();
        }
        public void Delete(Product product)
        {
            string json = JsonConvert.SerializeObject(product, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var httpResponce = _httpClient.PostAsync("api/Product/Delete", byteContent);
        }


    }
}

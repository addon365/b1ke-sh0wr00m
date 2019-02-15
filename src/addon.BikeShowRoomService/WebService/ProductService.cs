using Api.Database.Entity.Inventory.Products;
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
            _httpClient = WebDataClient.Client;
        }
        public IEnumerable<ProductCompany> GetCompanies()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Product/Companies").Result;
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
            HttpResponseMessage response = _httpClient.GetAsync("Product/Types").Result;
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
        public Threenine.Data.Paging.IPaginate<Product> GetAllActive(Api.Domain.Paging.PagingParams pagingParams)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Product?" + "PageNumber=" + pagingParams.PageNumber + "&PageSize=" + pagingParams.PageSize).Result;
            Threenine.Data.Paging.IPaginate<Product> products = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                products = JsonConvert.DeserializeObject<Threenine.Data.Paging.Paginate<Product>>(json);



            }

            return products;
        }
        public IEnumerable<Product> GetProductByType(int ProgrammerId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Product/"+ ProgrammerId).Result;
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
            var httpResponce = _httpClient.PostAsync("Product", byteContent);


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
            var httpResponce = _httpClient.PostAsync("Product", byteContent);


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
            var httpResponce = _httpClient.PostAsync("Product/Delete", byteContent);
        }


    }
}

using addon365.Database.Entity.Inventory.Catalog;
using Newtonsoft.Json;
using addon365.Database.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace addon365.WebClient.Service.WebService
{
    public class ProductService : IProductService
    {
        private static HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = WebDataClient.Client;
        }
        public IEnumerable<CatalogBrand> GetCompanies()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Product/Companies").Result;
            IEnumerable<CatalogBrand> companies = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                companies = JsonConvert.DeserializeObject<IEnumerable<CatalogBrand>>(json);


                
            }

            return companies;
        }
        public IEnumerable<CatalogType> GetTypes()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Product/Types").Result;
            IEnumerable<CatalogType> types = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                types = JsonConvert.DeserializeObject<IEnumerable<CatalogType>>(json);



            }

            return types;
        }
        public Threenine.Data.Paging.IPaginate<CatalogItem> GetAllActive(addon365.Domain.Entity.Paging.PagingParams pagingParams)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Product?" + "PageNumber=" + pagingParams.PageNumber + "&PageSize=" + pagingParams.PageSize).Result;
            Threenine.Data.Paging.IPaginate<CatalogItem> products = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                products = JsonConvert.DeserializeObject<Threenine.Data.Paging.Paginate<CatalogItem>>(json);



            }

            return products;
        }
        public IEnumerable<CatalogItem> GetProductByType(int ProgrammerId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Product/"+ ProgrammerId).Result;
            IEnumerable<CatalogItem> products = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                products = JsonConvert.DeserializeObject<IEnumerable<CatalogItem>>(json);



            }

            return products;
        }
        public string Insert(CatalogItem product)
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
        public string InsertProductType(CatalogType producttype)
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
        public CatalogItem GetProduct(string identifier)
        {
            throw new NotImplementedException();
        }
        public void Delete(CatalogItem product)
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

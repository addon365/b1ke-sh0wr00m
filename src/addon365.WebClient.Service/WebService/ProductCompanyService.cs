﻿using addon365.Database.Entity.Inventory.Products;
using Newtonsoft.Json;
using addon365.Database.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace addon365.WebClient.Service.WebService
{
    public class ProductCompanyService:IProductCompanyService
    {
        private static HttpClient _httpClient;

        public ProductCompanyService()
        {
            _httpClient = WebDataClient.Client;
        }
        public IEnumerable<ProductCompany> GetAllProductCompanies()
        {
            HttpResponseMessage response = _httpClient.GetAsync("ProductCompany").Result;
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
        public string Insert(ProductCompany productcompany)
        {
            string json = JsonConvert.SerializeObject(productcompany, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var stringContent = new StringContent(JsonConvert.SerializeObject(productcompany), Encoding.UTF8, "application/json");
            var httpResponce = _httpClient.PostAsync("ProductCompany", byteContent);


            Console.WriteLine(httpResponce);
            return null;
        }
        public ProductCompany GetProductCompany(string identifier)
        {
            throw new NotImplementedException();
        }
        public void Delete(ProductCompany productcompany)
        {
            string json = JsonConvert.SerializeObject(productcompany, Formatting.Indented);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var stringContent = new StringContent(JsonConvert.SerializeObject(productcompany), Encoding.UTF8, "application/json");
            var httpResponce = _httpClient.PostAsync("ProductCompany/Delete", byteContent);
        }
    }
}
using Api.Database.Entity;
using Newtonsoft.Json;
using Swc.Service.Base;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace addon.BikeShowRoomService.BaseService
{
    public abstract class BaseClientService<T> : IBaseService<T> where T : BaseEntityWithLogFields
    {
        protected readonly HttpClient _httpClient;
        public BaseClientService()
        {
            _httpClient = WebDataClient.Client;
        }
        public T Find(Guid id)
        {
            string url = getUrl() + "/" + id.ToString();
            var response = _httpClient.GetAsync(url)
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                var web = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                Exception ex = JsonConvert.DeserializeObject<Exception>(web);
                if (ex != null)
                    throw ex;
            }
            return null;
        }

        public IEnumerable<T> FindAll()
        {
            var response = _httpClient.GetAsync(getUrl())
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
            }
            else
            {
                var web = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                Exception ex = JsonConvert.DeserializeObject<Exception>(web);
                if (ex != null)
                    throw ex;
            }
            return new List<T>(0);
        }

        public T Save(T obj)
        {
            var response = _httpClient.PostAsync(getUrl(),
                new StringContent(
                    JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"))
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                var web = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                Exception ex = JsonConvert.DeserializeObject<Exception>(web);
                if (ex != null)
                    throw ex;
            }
            return null;
        }

        public T Update(Guid id,T obj)
        {
            string url = getUrl() + "/" + obj.Id.ToString();
            var response = _httpClient.PutAsync(url,
                new StringContent(
                    JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"))
                    .GetAwaiter()
                    .GetResult();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                var web = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();
                Exception ex = JsonConvert.DeserializeObject<Exception>(web);
                if (ex != null)
                    throw ex;
            }
            return null;
        }

        public abstract string getUrl();
    }
}

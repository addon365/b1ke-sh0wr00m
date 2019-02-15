using Api.Database.Entity.Inventory.Purchases;
using Api.Domain.Inventory;
using Api.Domain.Paging;
using Newtonsoft.Json;
using Swc.Service.Inventory;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace addon.BikeShowRoomService.WebService.Inventory
{
    public class PurchaseWebService : IPurchaseService
    {

        private readonly HttpClient _httpClient;


        public PurchaseWebService()
        {
            _httpClient = WebDataClient.Client;
        }

        public Task Delete(string identifier)
        {
            throw new NotImplementedException();
        }

        public Purchase Get(string identifier)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Purchase/Get/" + identifier).Result;
            Purchase Row = null;
            if (response.StatusCode==HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                Row = JsonConvert.DeserializeObject<Purchase>(json);

                return Row;

            }
            else if(response.StatusCode==HttpStatusCode.NotFound)
            {
                throw new Exception("Incorrect Id");
            }

            throw new Exception("Request Failed");

        }

        public IPaginate<Purchase> GetAll(PagingParams pagingParams)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Purchase?" + "PageNumber=" + pagingParams.PageNumber + "&PageSize=" + pagingParams.PageSize).Result;
            Threenine.Data.Paging.IPaginate<Purchase> Data = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                Data = JsonConvert.DeserializeObject<Threenine.Data.Paging.Paginate<Purchase>>(json);

                string j = json;

            }

            return Data;
        }

        public PurchaseMasterData GetInitilize()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Purchase/Init").Result;
            PurchaseMasterData MasterData = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                MasterData = JsonConvert.DeserializeObject<PurchaseMasterData>(json);

                return MasterData;

            }

            throw new Exception("Failed");

        }

        public async Task<Purchase> Insert(Purchase model)
        {
            
            var response = await _httpClient.PostAsync("Purchase", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json=await response.Content.ReadAsStringAsync();
                var purchase = JsonConvert.DeserializeObject<Purchase>(json);
                return purchase;
            }
            else
            {
                var web = await response.Content.ReadAsStringAsync();
                Exception ex = JsonConvert.DeserializeObject<Exception>(web);

                if (ex != null)
                    throw ex;
            }

            return null;


        }

        public Task<Purchase> Update(Purchase model)
        {
            throw new NotImplementedException();
        }
    }
}

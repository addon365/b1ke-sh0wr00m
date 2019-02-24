using addon365.Database.Entity.Inventory;
using addon365.Database.Entity.Inventory.Purchases;
using addon365.Domain.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using Newtonsoft.Json;
using addon365.Database.Service.Inventory;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace addon365.WebClient.Service.WebService.Inventory
{
    public class SellerWebService : ISellerService
    {

        private readonly HttpClient _httpClient;
        private readonly string ApiHead ="Seller/";

        public SellerWebService()
        {
            _httpClient = WebDataClient.Client;

        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Seller Get(string id)
        {
            HttpResponseMessage response = _httpClient.GetAsync(ApiHead+"Get/"+id).Result;
            Seller row = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                row = JsonConvert.DeserializeObject<Seller>(json);

                return row;

            }

            throw new Exception("Request Failed");
        }

        public IPaginate<Seller> GetAll(PagingParams pagingParams)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Seller?" + "PageNumber=" + pagingParams.PageNumber + "&PageSize=" + pagingParams.PageSize).Result;
            Threenine.Data.Paging.IPaginate<Seller> rows = null;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                rows = JsonConvert.DeserializeObject<Threenine.Data.Paging.Paginate<Seller>>(json);

                string j = json;

            }

            return rows;
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

        public async Task<Seller> Insert(Seller model)
        {
            var response = await _httpClient.PostAsync(ApiHead , new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                var enquiries = JsonConvert.DeserializeObject<Seller>(json);

                return enquiries;

            }
            else
            {
                var web = await response.Content.ReadAsStringAsync();
                Exception ex = JsonConvert.DeserializeObject<Exception>(web);

                if (ex != null)
                    throw ex;
            }


            throw new Exception("Failed");
        }

        public async Task<Seller> Update(Seller model)
        {
            var response = await _httpClient.PostAsync(ApiHead+"Update", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                .GetAwaiter()
                                .GetResult();

                var sellers = JsonConvert.DeserializeObject<Seller>(json);

                return sellers;

            }
            else
            {
                var web = await response.Content.ReadAsStringAsync();
                Exception ex = JsonConvert.DeserializeObject<Exception>(web);

                if (ex != null)
                    throw ex;
            }


            throw new Exception("Failed");
        }
    }
    
}

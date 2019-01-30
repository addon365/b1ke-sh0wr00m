using Api.Database.Entity.Inventory;
using Api.Database.Entity.Inventory.Purchases;
using Api.Domain.Inventory;
using Api.Domain.Paging;
using Newtonsoft.Json;
using Swc.Service.Inventory;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace addon.BikeShowRoomService.WebService.Inventory
{
    public class BuyerWebService : IBuyerService
    {

        private readonly HttpClient _httpClient;


        public BuyerWebService()
        {
            _httpClient = WebDataClient.Client;
        }

        public Task Delete(string identifier)
        {
            throw new NotImplementedException();
        }

        public Buyer Get(string identifier)
        {
            throw new NotImplementedException();
        }

        public IPaginate<Buyer> GetAll(PagingParams pagingParams)
        {
            throw new NotImplementedException();
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

        public Task<Buyer> Insert(Buyer model)
        {
            throw new NotImplementedException();
        }

        public Task<Buyer> Update(Buyer model)
        {
            throw new NotImplementedException();
        }
    }
}

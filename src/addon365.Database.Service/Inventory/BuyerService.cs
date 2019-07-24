using addon365.Database.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using addon365.IService.Inventory;
using System;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace addon365.Database.Service.Inventory
{
    public class BuyerService : IBuyerService
    {
        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Buyer Get(string id)
        {
            throw new NotImplementedException();
        }

        public IPaginate<Buyer> GetAll(PagingParams pagingParams)
        {
            throw new NotImplementedException();
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

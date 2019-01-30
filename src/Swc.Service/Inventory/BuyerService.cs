using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Database.Entity.Inventory;
using Api.Domain.Paging;
using Threenine.Data.Paging;

namespace Swc.Service.Inventory
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

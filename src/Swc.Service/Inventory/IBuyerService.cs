using addon365.Database.Entity.Inventory;
using addon365.Database.Entity.Inventory.Purchases;
using addon365.Domain.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace addon365.Database.Service.Inventory
{
    public interface IBuyerService
    {
        IPaginate<Buyer> GetAll(PagingParams pagingParams);
        Task<Buyer> Insert(Buyer model);
        Task<Buyer> Update(Buyer model);
        Buyer Get(string id);
        Task Delete(string id);
    }
}

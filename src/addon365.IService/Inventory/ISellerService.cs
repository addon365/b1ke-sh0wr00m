using addon365.Database.Entity.Inventory;
using addon365.Database.Entity.Inventory.Purchases;
using addon365.Domain.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace addon365.IService.Inventory
{
    public interface ISellerService
    {
        IPaginate<Seller> GetAll(PagingParams pagingParams);
        Task<Seller> Insert(Seller model);
        Task<Seller> Update(Seller model);
        Seller Get(string id);
        Task Delete(string id);
    }
}

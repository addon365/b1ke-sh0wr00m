using Api.Database.Entity.Inventory;
using Api.Database.Entity.Inventory.Purchases;
using Api.Domain.Inventory;
using Api.Domain.Paging;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace Swc.Service.Inventory
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

using Api.Database.Entity.Inventory;
using Api.Database.Entity.Inventory.Purchases;
using Api.Domain.Inventory;
using Api.Domain.Paging;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace Swc.Service.Inventory
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

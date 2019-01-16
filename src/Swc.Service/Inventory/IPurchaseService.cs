using Api.Database.Entity.Inventory.Purchase;
using Api.Domain.Inventory;
using Api.Domain.Paging;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace Swc.Service.Inventory
{
    public interface IPurchaseService
    {
        IPaginate<Purchase> GetAll(PagingParams pagingParams);
        PurchaseMasterData GetInitilize();
        Task<Purchase> Insert(Purchase model);
        Task<Purchase> Update(Purchase model);
        Purchase Get(string identifier);
        Task Delete(string identifier);
    }
}

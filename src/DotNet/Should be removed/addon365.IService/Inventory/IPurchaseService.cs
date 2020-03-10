using addon365.Database.Entity.Inventory.Purchases;
using addon365.Domain.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using System.Threading.Tasks;
using Threenine.Data.Paging;

namespace addon365.IService.Inventory
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


using addon365.Database.Entity.Inventory.Sales;
using addon365.Domain.Entity.Sales;
using System.Threading.Tasks;

namespace addon365.IService.Sales
{
    public interface ISalesService
    {

        InitilizeSales GetInitilizeSales();
        Task<string> Insert(Sale model);
    }
}
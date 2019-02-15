
using Api.Database.Entity.Inventory.Sales;
using Api.Domain.Sales;
using System.Threading.Tasks;

namespace Swc.Service.Sales
{
    public interface ISalesService
    {

        InitilizeSales GetInitilizeSales();
        Task<string> Insert(Sale model);
    }
}
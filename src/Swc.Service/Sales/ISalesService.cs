
using Api.Domain.Enquiries;
using Api.Domain.Sales;
using System.Threading.Tasks;

namespace Swc.Service.Sales
{
    public interface ISalesService
    {

        InitilizeSales GetInitilizeSales();
        Task<string> Insert(InsertSalesModel model);
    }
}
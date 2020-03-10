using addon365.Domain.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using Threenine.Data.Paging;

namespace addon365.IService.Inventory
{
    public interface IProductReportService
    {
        Paginate<ProductWise> GetAllSalesProductWise(PagingParams pagingParams);
        Paginate<ProductWise> GetAllPurchaseProductWise(PagingParams pagingParams);
        Paginate<StockProductWise> GetAllStockProductWise(PagingParams pagingParams);
    }
}

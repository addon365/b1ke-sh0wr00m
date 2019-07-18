using addon365.Domain.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using addon365.IService.Inventory;
using System;
using Threenine.Data.Paging;

namespace addon365.Database.Service.Inventory
{
    public class ProductReportService : IProductReportService
    {
        public Paginate<ProductWise> GetAllPurchaseProductWise(PagingParams pagingParams)
        {
            throw new NotImplementedException();
        }

        public Paginate<ProductWise> GetAllSalesProductWise(PagingParams pagingParams)
        {
            throw new NotImplementedException();
        }

        public Paginate<StockProductWise> GetAllStockProductWise(PagingParams pagingParams)
        {
            throw new NotImplementedException();
        }
    }
}

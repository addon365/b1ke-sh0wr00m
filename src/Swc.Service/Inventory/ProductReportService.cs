using System;
using System.Collections.Generic;
using System.Text;
using Api.Domain.Inventory;
using Api.Domain.Paging;
using Threenine.Data.Paging;

namespace Swc.Service.Inventory
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

using Api.Domain.Inventory;
using Api.Domain.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using Threenine.Data.Paging;

namespace Swc.Service.Inventory
{
    public interface IProductReportService
    {
        Paginate<ProductWise> GetAllSalesProductWise(PagingParams pagingParams);
        Paginate<ProductWise> GetAllPurchaseProductWise(PagingParams pagingParams);
        Paginate<StockProductWise> GetAllStockProductWise(PagingParams pagingParams);
    }
}

using addon365.Database.Entity.Inventory.Catalog;
using addon365.Domain.Entity.Paging;
using System.Collections.Generic;

namespace addon365.IService
{
    public interface IProductService
    {
        Threenine.Data.Paging.IPaginate<CatalogItem> GetAllActive(PagingParams pagingParams);
        string Insert(CatalogItem CatalogItem);
        string InsertProductType(CatalogType Type);
        void Delete(CatalogItem product);
        CatalogItem GetProduct(string identifier);
        IEnumerable<CatalogBrand> GetCompanies();
        IEnumerable<CatalogType> GetTypes();
        IEnumerable<CatalogItem> GetProductByType(int ProgrammerId);

    }
}

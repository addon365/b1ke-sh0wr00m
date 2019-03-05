using addon365.Database.Entity.Inventory.Catalog;
using System.Collections.Generic;

namespace addon365.Database.Service
{
    public interface IProductCompanyService
    {
        IEnumerable<CatalogBrand> GetAllProductCompanies();
        string Insert(CatalogBrand productcompany);
        CatalogBrand GetProductCompany(string identifier);
        void Delete(CatalogBrand productcompany);

    }
}

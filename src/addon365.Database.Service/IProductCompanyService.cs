using addon365.Database.Entity.Inventory.Products;
using System.Collections.Generic;

namespace addon365.Database.Service
{
    public interface IProductCompanyService
    {
        IEnumerable<ProductCompany> GetAllProductCompanies();
        string Insert(ProductCompany productcompany);
        ProductCompany GetProductCompany(string identifier);
        void Delete(ProductCompany productcompany);

    }
}

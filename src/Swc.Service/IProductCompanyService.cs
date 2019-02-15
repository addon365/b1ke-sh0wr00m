using Api.Database.Entity.Inventory.Products;
using System.Collections.Generic;

namespace Swc.Service
{
    public interface IProductCompanyService
    {
        IEnumerable<ProductCompany> GetAllProductCompanies();
        string Insert(ProductCompany productcompany);
        ProductCompany GetProductCompany(string identifier);
        void Delete(ProductCompany productcompany);

    }
}

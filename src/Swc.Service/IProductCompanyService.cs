using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swc.Service
{
    public interface IProductCompanyService
    {
        IEnumerable<ProductCompany> GetAllProductCompanies();
        string Insert(ProductCompany productcompany);
        ProductCompany GetProductCompany(string identifier);
       
    }
}

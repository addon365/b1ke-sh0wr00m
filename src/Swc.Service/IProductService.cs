﻿using Api.Database.Entity.Products;
using Api.Domain.Enquiries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swc.Service
{
  public interface IProductService
    {
        IEnumerable<Product> GetAllActive();
        string Insert(Product product);
        string InsertProductType(ProductType product);
        void Delete(Product product);
        Product GetProduct(string identifier);
        IEnumerable<ProductCompany> GetCompanies();
        IEnumerable<ProductType> GetTypes();
        IEnumerable<Product> GetProductByType(int ProgrammerId);

    }
}

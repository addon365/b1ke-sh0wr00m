using Api.Database.Entity.Products;
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
        Product GetProduct(string identifier);
    }
}

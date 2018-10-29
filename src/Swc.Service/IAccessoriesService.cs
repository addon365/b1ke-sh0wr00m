using Api.Database.Entity.Products;
using Api.Domain.Enquiries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swc.Service
{
  public interface IAccessoriesService
    {
        
        string InsertAccessories(IEnumerable<ExtraFittingsAccessories> extrafittings);
        IEnumerable<ExtraFittingsAccessories> GetAccessories();
        IEnumerable<ExtraFittingsAccessories> GetAccessories(Guid ProductId);
        string UpdateAccessories(IEnumerable<ExtraFittingsAccessories> extrafittings);
        void DeleteAccessories(Guid ProductId);

     }
}

using addon365.Database.Entity.Inventory.Products;
using System;
using System.Collections.Generic;

namespace addon365.Database.Service
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

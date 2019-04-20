using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;

namespace addon365.IService
{
    public interface IAccessoriesService
    {
        
        string InsertAccessories(IEnumerable<ExtraFittingsAccessories> extrafittings);
        IEnumerable<ExtraFittingsAccessories> GetAccessories();
        IEnumerable<ExtraFittingsAccessories> GetAccessories(Guid CatalogItemId);
        string UpdateAccessories(IEnumerable<ExtraFittingsAccessories> extrafittings);
        void DeleteAccessories(Guid CatalogItemId);

     }
}

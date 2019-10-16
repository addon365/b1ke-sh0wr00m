using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.IService.AddonLicense
{
    public interface IAddonLicenservice
    {
        IEnumerable<CustomerCatalogGroup> GetAll();
        void Add(CustomerCatalogGroup customerCatalogGroup);
    }
}

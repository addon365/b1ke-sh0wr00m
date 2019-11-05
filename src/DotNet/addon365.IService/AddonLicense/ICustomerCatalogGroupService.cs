using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Entity.License;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace addon365.IService.AddonLicense
{
    public interface ICustomerCatalogGroupService
    {
        IEnumerable<CustomerCatalogGroup> GetAll();

        public bool TryGetLicense(string id, out CustomerCatalogGroup license);
        public List<CustomerCatalogGroup> GetLicenses();
        public Task<int> Add(CustomerCatalogGroup customerCatalogGroup);
        IEnumerable<LicensedHardware> GetLicensedHardwares();
        public Task<int> AddHardware(Guid AppIdPrimaryKey, string HardwareId);
    }
}

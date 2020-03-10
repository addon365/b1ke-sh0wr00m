using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Entity.License;
using addon365.Domain.Entity.AddonLicense;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace addon365.IService.AddonLicense
{
    public interface IAddonLicenservice
    {
        IEnumerable<LicenseDetail> GetAll();

        public bool TryGetLicense(string id, out LicenseDetail license);
        public List<CustomerCatalogGroup> GetLicenses();
        public int Add(CustomerCatalogGroup customerCatalogGroup);
        IEnumerable<LicensedHardware> GetLicensedHardwares();
        public int AddHardware(LicenseActivationDetail lad);

        public bool ActivateLicense(LicenseActivationDetail lad);
    }
   
}

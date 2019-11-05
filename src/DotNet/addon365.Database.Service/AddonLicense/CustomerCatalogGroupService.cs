using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Entity.License;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Threenine.Data;

namespace addon365.Database.Service.AddonLicense
{
    public class CustomerCatalogGroupService : addon365.IService.AddonLicense.ICustomerCatalogGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerCatalogGroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

     
        public IEnumerable<CustomerCatalogGroup> GetAll()
        {
            return _unitOfWork.GetRepository<CustomerCatalogGroup>().GetList().Items;
        }

        public List<CustomerCatalogGroup> GetLicenses() =>
           new List<CustomerCatalogGroup>(_unitOfWork.GetRepository<CustomerCatalogGroup>().GetList().Items);

        //public IAsyncEnumerable<CustomerCatalogGroup> GetProductsAsync() =>
        //    _unitOfWork.GetRepositoryAsync<CustomerCatalogGroup>().GetListAsync();


        public bool TryGetLicense(string id, out CustomerCatalogGroup license)
        {
            license = _unitOfWork.GetRepository<CustomerCatalogGroup>().Single(x => x.CustomerCatalogGroupId == id);

            return (license != null);
        }

        public async Task<int> Add(CustomerCatalogGroup customerCatalogGroup)
        {
            await _unitOfWork.GetRepositoryAsync<CustomerCatalogGroup>().AddAsync(customerCatalogGroup);
            return _unitOfWork.SaveChanges();
        }
        public IEnumerable<LicensedHardware> GetLicensedHardwares()
        {
            return _unitOfWork.GetRepository<LicensedHardware>().GetList().Items;
        }
        public async Task<int> AddHardware(Guid AppIdPrimaryKey, string HardwareId)
        {
            LicensedHardware licensedHardware = new LicensedHardware();
            licensedHardware.HardwareId = HardwareId;
            licensedHardware.CustomerCatalogGroupId = AppIdPrimaryKey;
            licensedHardware.ActivatedDate = System.DateTime.Now;
            await _unitOfWork.GetRepositoryAsync<LicensedHardware>().AddAsync(licensedHardware);
            return _unitOfWork.SaveChanges();
        }
    }
}

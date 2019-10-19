using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using Threenine.Data;

namespace addon365.Database.Service.AddonLicense
{
    public class AddonLicenseService:addon365.IService.AddonLicense.IAddonLicenservice
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddonLicenseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CustomerCatalogGroup> GetAll()
        {
            return _unitOfWork.GetRepository<CustomerCatalogGroup>().GetList().Items;
        }
        public void Add(CustomerCatalogGroup customerCatalogGroup)
        {
            _unitOfWork.GetRepository<CustomerCatalogGroup>().Add(customerCatalogGroup);
            _unitOfWork.SaveChanges();
        }
    }
}

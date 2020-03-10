using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Entity.License;
using addon365.Domain.Entity.AddonLicense;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
namespace addon365.Database.Service.AddonLicense
{
    public class AddonLicenseService:addon365.IService.AddonLicense.IAddonLicenservice
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddonLicenseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<LicenseDetail> GetAll()

        {
            IList<LicenseDetail> lstLicenseDetail = new List<LicenseDetail>();
            foreach (var CustomerCatalogGroup in _unitOfWork.GetRepository<CustomerCatalogGroup>().GetList(include: x => x.
             Include(c => c.Customer).ThenInclude(con => con.BusinessContact).ThenInclude(per => per.ContactPerson)
             .Include(r => r.RenewedDetail)).Items)
            {

                lstLicenseDetail.Add(new LicenseDetail() {CustomerCatalogGroupId=CustomerCatalogGroup.CustomerCatalogGroupId });
            }

            return lstLicenseDetail;
        }
       

        public List<CustomerCatalogGroup> GetLicenses() =>
           new List<CustomerCatalogGroup>(_unitOfWork.GetRepository<CustomerCatalogGroup>().GetList(predicate: x => x.Customer !=null,include: x => x.
             Include(c => c.Customer).ThenInclude(con => con.BusinessContact).ThenInclude(per => per.ContactPerson)
             .Include(r => r.RenewedDetail)).Items);

        //public IAsyncEnumerable<CustomerCatalogGroup> GetProductsAsync() =>
        //    _unitOfWork.GetRepositoryAsync<CustomerCatalogGroup>().GetListAsync();

      
        public bool TryGetLicense(string id, out LicenseDetail license)
        {
            var catalog = _unitOfWork.GetRepository<CustomerCatalogGroup>().Single(predicate: x => x.CustomerCatalogGroupId == id,
              include: x => x.
              Include(c =>c.Customer).ThenInclude(con=>con.BusinessContact).ThenInclude(per=>per.ContactPerson)
              .Include(r=>r.RenewedDetail));
            if (catalog == null)
            {
                license = null;
                return false;
            }
            license = new LicenseDetail();

            license.CustomerCatalogGroupId = catalog.CustomerCatalogGroupId;
            license.NumberofSystem = catalog.NumberofSystem;
            if(catalog.RenewedDetail!=null)
            license.ExpiryDate = catalog.RenewedDetail.ExpiryDate;

            if (catalog.Customer != null)
            {
                if (catalog.Customer.BusinessContact != null)
                {
                    license.BusinessName = catalog.Customer.BusinessContact.BusinessName;
                    license.MobileNo = catalog.Customer.MobileNo;
                    license.EmailId = catalog.Customer.CustomerEmailId;
                    if (catalog.Customer.BusinessContact.ContactPerson != null)
                    {
                        license.ContactPersonName = catalog.Customer.BusinessContact.ContactPerson.FirstName;
                    }
                }
                
            }
       
            license.ActiveSystemCount = _unitOfWork.GetRepository<LicensedHardware>().GetList(x => x.CustomerCatalogGroupId == catalog.Id).Count;

            return (license != null);
        }

        public int Add(CustomerCatalogGroup customerCatalogGroup)
        {
             _unitOfWork.GetRepository<CustomerCatalogGroup>().Add(customerCatalogGroup);
            return _unitOfWork.SaveChanges();
        }
        public IEnumerable<LicensedHardware> GetLicensedHardwares()
        {
            return _unitOfWork.GetRepository<LicensedHardware>().GetList().Items;
        }
        public int AddHardware(LicenseActivationDetail lad)
        {
            var catalog = _unitOfWork.GetRepository<CustomerCatalogGroup>().Single(x => x.CustomerCatalogGroupId == lad.CustomerCatalogGroupId);
            LicensedHardware licensedHardware = new LicensedHardware();
            licensedHardware.HardwareId = lad.HardwareId;
            licensedHardware.CustomerCatalogGroupId = catalog.Id;
            licensedHardware.DeviceName = lad.DeviceName;
            licensedHardware.DeviceType = lad.DeviceType;
            licensedHardware.DeviceComment = lad.DeviceComment;
            licensedHardware.MacAddress = lad.MacAddress;
            licensedHardware.ActivatedDate = System.DateTime.Now;
            _unitOfWork.GetRepository<LicensedHardware>().Add(licensedHardware);
            return _unitOfWork.SaveChanges();
        }
        public bool ActivateLicense(LicenseActivationDetail lad)
        {

            try
            {
                var catalog = _unitOfWork.GetRepository<CustomerCatalogGroup>().Single(x => x.CustomerCatalogGroupId == lad.CustomerCatalogGroupId);

                

                BusinessContact businessContact = new BusinessContact();
                businessContact.BusinessName = lad.BusinessName;
                businessContact.MobileNumber = lad.MobileNo;

                Contact contact = new Contact();
                contact.FirstName = lad.ContactPersonName;
                
                businessContact.ContactPerson = contact;

                Customer cus = new Customer();
                cus.BusinessContact = businessContact;
                cus.CustomerEmailId = lad.EmailId;
                cus.MobileNo = lad.MobileNo;

                catalog.NumberofSystem = 1;
                catalog.Customer = cus;
                LicenseRenewedDetail licenseRenewed = new LicenseRenewedDetail();
                licenseRenewed.CustomerCatalogGroupId = catalog.Id;
                licenseRenewed.RenewedDate = System.DateTime.Now;
                licenseRenewed.ExpiryDate = System.DateTime.Now.AddDays(10);
                
                _unitOfWork.GetRepository<LicenseRenewedDetail>().Add(licenseRenewed);

                catalog.RenewedDetailId = licenseRenewed.Id;

                _unitOfWork.GetRepository<BusinessContact>().Add(businessContact);
                _unitOfWork.GetRepository<Contact>().Add(contact);
                _unitOfWork.GetRepository<Customer>().Add(cus);

                _unitOfWork.GetRepository<CustomerCatalogGroup>().Update(catalog);

                //LicensedHardware licensedHardware = new LicensedHardware();
                //licensedHardware.HardwareId = lad.HardwareId;
                //licensedHardware.CustomerCatalogGroupId = catalog.Id;
                //licensedHardware.ActivatedDate = System.DateTime.Now;
                //_unitOfWork.GetRepository<LicensedHardware>().Add(licensedHardware);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }

           
        }
    }
    
}

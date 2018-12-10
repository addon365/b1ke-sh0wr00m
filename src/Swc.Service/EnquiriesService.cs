using System;
using System.Collections.Generic;
using System.Linq;
using Api.Database.Entity.Threats;
using Api.Domain.Enquiries;
using Threenine.Data;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity;
using Api.Database.Entity.Products;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Api.Database.Entity.Crm;

namespace Swc.Service
{
    public class EnquiryService : IEnquiriesService
    {
      
        private readonly IUnitOfWork _unitOfWork;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";

        public EnquiryService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IEnumerable<Enquiries> GetAllActive()
        {
            List<Enquiries> lst = new List<Enquiries>();

            var enquiries = _unitOfWork.GetRepository<Enquiry>().GetList().Items;
        
       
            foreach(Enquiry enquiry in enquiries)
            {
                Enquiries e = new Enquiries();
                e.EnquiryId = enquiry.Id;
                e.Identifier = enquiry.Identifier;
                e.Created = enquiry.Created;
                e.Contact = _unitOfWork.GetRepository<Contact>().GetList(predicate: x => x.Id == enquiry.ContactId).Items.FirstOrDefault();
                e.Status = _unitOfWork.GetRepository<EnquiryStatus>().GetList().Items.Where(predicate: x => x.Id == enquiry.StatusId).FirstOrDefault();
                e.EnquiryType = _unitOfWork.GetRepository<EnquiryType>().GetList().Items.Where(predicate: x => x.Id == enquiry.EnquiryTypeId).FirstOrDefault();
                e.EnquiryProducts = _unitOfWork.GetRepository<EnquiryProduct>().GetList().Items.Where(predicate: x => x.EnquiryId == enquiry.Id).FirstOrDefault();
                if(e.EnquiryProducts!=null)
                e.EnquiryProducts.Product= _unitOfWork.GetRepository<Product>().GetList().Items.Where(predicate: x => x.Id ==e.EnquiryProducts.ProductId).FirstOrDefault();
                lst.Add(e);
            }
          return lst.OrderBy(s=>s.Created);
          
        }
        public InitilizeEnquiry GetInitilizeEnquiries()
        {
            InitilizeEnquiry ie = new InitilizeEnquiry();
            ie.MarketingZones = _unitOfWork.GetRepository<MarketingZone>().GetList().Items;
            ie.Products = _unitOfWork.GetRepository<Product>().GetList().Items;
            ie.enquiryTypes = _unitOfWork.GetRepository<EnquiryType>().GetList().Items;

            return ie;

        }

        public async Task<string> Insert(InsertEnquiryModel InsertEnquiries)
        {
            try
            { 

            #region  autoMap
            // TODO : Move this to a cache lookup.  We don't want to query on every ADD.
            // TODO :  Expected Volumes could be immense to so we need to optimise 
            //var refType = _unitOfWork.GetRepository<EnquiryType>().GetList(x => x.Name == Referer).SingleOrDefault();
            //var status = _unitOfWork.GetRepository<EnquiryStatus>().GetList(x => x.Name == Moderate).SingleOrDefault();

            //var enquiry = Mapper.Map<Enquiry>(enquiries);

            //enquiry.StatusId = status.Id;
            //enquiry.EnquiryTypeId = refType.Id;
            //enquiry.EnquiryType = refType;
            //enquiry.Status = status;
            #endregion
            //var enquirystatus = new EnquiryStatus();
            //enquirystatus.Name = "Registred";

            //var enquirytype = new EnquiryType();
            //enquirytype.Name = "InHouse";

            var enquiry = new Enquiry();
            var contact = new Contact();
            contact.Name = InsertEnquiries.Enquiry.Contact.Name;
            contact.MobileNumber = InsertEnquiries.Enquiry.Contact.MobileNumber;
            contact.Place = InsertEnquiries.Enquiry.Contact.Place;
            contact.Address = InsertEnquiries.Enquiry.Contact.Address;
            enquiry.Contact = contact;
                var lst = _unitOfWork.GetRepository<Enquiry>()
                         .GetList().Items;

                string identi = "1";
                if(lst!=null)
                {
                    if(lst.Count>0)
                        identi=(lst.Max(e => Convert.ToInt64(e.Identifier))+1).ToString();
                }
                    
                
            enquiry.Identifier =identi ;

                enquiry.ContactId = contact.Id;
            enquiry.StatusId=_unitOfWork.GetRepository<EnquiryStatus>()
                .GetList().Items.Where(predicate: x => x.ProgrammerId==100).First().Id;
            enquiry.EnquiryTypeId = _unitOfWork.GetRepository<EnquiryType>()
           .GetList().Items.Where(predicate: x => x.ProgrammerId == 100).First().Id;
            _unitOfWork.GetRepository<Contact>().Add(contact);
            _unitOfWork.GetRepository<Enquiry>().Add(enquiry);
            foreach(EnquiryProduct ep in InsertEnquiries.EnquiryProducts)
            {
                ep.Product = null;
                ep.EnquiryId = enquiry.Id;
            _unitOfWork.GetRepository<EnquiryProduct>().Add(ep);
            }
            foreach(EnquiryFinanceQuotation efq in InsertEnquiries.enquiryFinanceQuotations)
            {
               
                _unitOfWork.GetRepository<EnquiryFinanceQuotation>().Add(efq);
            }
            foreach(EnquiryExchangeQuotation eeq in InsertEnquiries.enquiryExchangeQuotations)
            {
                eeq.EnquiryId = enquiry.Id;
                _unitOfWork.GetRepository<EnquiryExchangeQuotation>().Add(eeq);
            }


           
                 _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {
                string exmsg = ex.Message;
            }
            return InsertEnquiries.Enquiry.Identifier;

        }

        public InsertEnquiryModel GetEnquiries(string identifier)
        {
           InsertEnquiryModel ine= new InsertEnquiryModel();
            Enquiry enquiry = new Enquiry();
            enquiry = _unitOfWork.GetRepository<Enquiry>().GetList().Items.Where(predicate: x => x.Identifier == identifier).FirstOrDefault();
            if(enquiry==null)
               return null;
            
            enquiry.Contact= _unitOfWork.GetRepository<Contact>().GetList().Items.Where(predicate: x => x.Id == enquiry.ContactId).FirstOrDefault();
            ine.Enquiry = enquiry;

            ine.EnquiryProducts= _unitOfWork.GetRepository<EnquiryProduct>().GetList().Items.Where(predicate: x => x.EnquiryId == enquiry.Id);
            ine.enquiryAccessories = _unitOfWork.GetRepository<EnquiryAccessories>().GetList().Items.Where(predicate: x => x.EnquiryId == enquiry.Id);
            ine.enquiryExchangeQuotations= _unitOfWork.GetRepository<EnquiryExchangeQuotation>().GetList().Items.Where(predicate: x => x.EnquiryId == enquiry.Id);
            ine.enquiryFinanceQuotations = null; /*_unitOfWork.GetRepository<EnquiryFinanceQuotation>().GetList().Items.Where(predicate: x => x.EnquiryId == enquiry.Id);*/

            return ine;
        }
        public MultiEnquiryModel GetMultiEnquiries(string identifier)
        {
            MultiEnquiryModel ine = new MultiEnquiryModel();
            List<Enquiry> lstEnquiry = new List<Enquiry>();
            List<Contact> lstContacts = new List<Contact>();
            Enquiry enquiry = new Enquiry();
            enquiry = _unitOfWork.GetRepository<Enquiry>().GetList().Items.Where(predicate: x => x.Identifier == identifier).FirstOrDefault();
            if (enquiry == null)
                return null;

            lstEnquiry.Add(enquiry);
            lstContacts.Add(_unitOfWork.GetRepository<Contact>().GetList().Items.Where(predicate: x => x.Id == enquiry.ContactId).FirstOrDefault());
         
            ine.enquiries = lstEnquiry;
            ine.contacts = lstContacts;

            List<DomainEnquiryProduct> lstEnquiryProducts = new List<DomainEnquiryProduct>();
            foreach(EnquiryProduct ep in _unitOfWork.GetRepository<EnquiryProduct>().GetList().Items.Where(predicate: x => x.EnquiryId == enquiry.Id))
            {
                DomainEnquiryProduct dp = new DomainEnquiryProduct { Id = ep.Id,EnquiryId=ep.EnquiryId, ProductId = ep.ProductId,OnRoadPrice=ep.OnRoadPrice,TotalAmount=ep.TotalAmount };
                dp.ProductName = _unitOfWork.GetRepository<Product>().GetList().Items.Where(predicate: x => x.Id == dp.ProductId).FirstOrDefault().ProductName;
                lstEnquiryProducts.Add(dp);
            }
            ine.EnquiryProducts =lstEnquiryProducts ;
            ine.enquiryAccessories = _unitOfWork.GetRepository<EnquiryAccessories>().GetList().Items.Where(predicate: x => x.EnquiryId == enquiry.Id);
            ine.enquiryExchangeQuotations = _unitOfWork.GetRepository<EnquiryExchangeQuotation>().GetList().Items.Where(predicate: x => x.EnquiryId == enquiry.Id);
            //ine.enquiryFinanceQuotations = _unitOfWork.GetRepository<EnquiryFinanceQuotation>().GetList().Items.Where(predicate: x => x.EnquiryId == enquiry.Id);

            return ine;
        }
    }
}

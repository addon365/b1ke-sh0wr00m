﻿using System;
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
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Paging;

namespace Swc.Service
{
    public class EnquiryService : IEnquiriesService
    {
      
        private readonly IUnitOfWork _unitOfWork;
       
        private ILogger<EnquiryService> _looger;
        private RequestInfo _requestInfo;
        public EnquiryService(IUnitOfWork unitOfWork,ILogger<EnquiryService> logger,RequestInfo requestInfo)
        {
           _unitOfWork = unitOfWork;
            this._looger = logger;
            _requestInfo = requestInfo;
        }
        public Threenine.Data.Paging.IPaginate<Enquiry> GetAllActive(PagingParams pagingParams)
        {
           
            var enquiries = _unitOfWork.GetRepository<Enquiry>().GetList(
                orderBy: x => x.OrderBy(m => m.Created),
                predicate:x=>x.BranchMasterId.ToString()==_requestInfo.BranchId && (x.VoucherId==null || x.VoucherId==Guid.Empty),
                include: x => x.
                Include(Contact => Contact.Contact).
                Include(Status => Status.Status).
                Include(m => m.EnquiryType).
                Include(n => n.EnquiryProducts).ThenInclude(c => c.Product).
                Include(n => n.EnquiryProducts).ThenInclude(a=>a.EnquiryFinanceQuotations).
                Include(n=>n.EnquiryExchangeQuotations), 
                index: pagingParams.PageNumber, size:pagingParams.PageSize);
               


            return enquiries;
            
        }
      
        public InitilizeEnquiry GetInitilizeEnquiries()
        {
            InitilizeEnquiry ie = new InitilizeEnquiry();
            ie.MarketingZones = _unitOfWork.GetRepository<MarketingZone>().GetList().Items;
            ie.Products = _unitOfWork.GetRepository<Product>().GetList().Items;
            ie.enquiryTypes = _unitOfWork.GetRepository<EnquiryType>().GetList().Items;

            return ie;

        }

        public async Task<Enquiry> Insert(InsertEnquiryModel InsertEnquiries)
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

            _requestInfo.InitilizeBaseEntityInfo(enquiry);
            var contact = new Contact();
            contact.Name = InsertEnquiries.Enquiry.Contact.Name;
            contact.MobileNumber = InsertEnquiries.Enquiry.Contact.MobileNumber;
            contact.Place = InsertEnquiries.Enquiry.Contact.Place;
            contact.Address = InsertEnquiries.Enquiry.Contact.Address;
            enquiry.Contact = contact;
                var Branch= _unitOfWork.GetRepository<BranchMaster>()
                         .GetList(predicate: x => x.Id == enquiry.BranchMasterId).Items;

                String BranchShortCode = "";
                if (Branch != null)
                    BranchShortCode = Branch.FirstOrDefault().ShortCode;

                var lst = _unitOfWork.GetRepository<Enquiry>()
                         .GetList(predicate:x=>x.BranchMasterId== enquiry.BranchMasterId).Items;

                string identi = BranchShortCode+"1";
                if(lst!=null)
                {
                    if(lst.Count>0)
                        identi= BranchShortCode+(lst.Max(e => Convert.ToInt64(e.Identifier.Remove(0,1)))+1).ToString();
                }
                    
                
            enquiry.Identifier =identi ;
            enquiry.EnquiryDate = InsertEnquiries.Enquiry.EnquiryDate;

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
                    if(ep.EnquiryFinanceQuotations!=null)
                    foreach (EnquiryFinanceQuotation efq in ep.EnquiryFinanceQuotations)
                    {

                        _unitOfWork.GetRepository<EnquiryFinanceQuotation>().Add(efq);
                    }
                    _unitOfWork.GetRepository<EnquiryProduct>().Add(ep);
            }
         
            
            foreach(EnquiryExchangeQuotation eeq in InsertEnquiries.enquiryExchangeQuotations)
            {
                eeq.EnquiryId = enquiry.Id;
                if(eeq.Model!="")
                _unitOfWork.GetRepository<EnquiryExchangeQuotation>().Add(eeq);
            }


           
                 _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {
                string exmsg = ex.Message;
            }
            return GetEnquiries(InsertEnquiries.Enquiry.Identifier);

        }

        public Enquiry GetEnquiries(string identifier)
        {

            var enq = _unitOfWork.GetRepository<Enquiry>().Single(
              orderBy: x => x.OrderBy(m => m.Created),
              predicate: x => x.BranchMasterId.ToString() == _requestInfo.BranchId && x.Identifier.ToLower()==identifier.ToLower(),
              include: x => x.
              Include(Contact => Contact.Contact).
              Include(Status => Status.Status).
              Include(m => m.EnquiryType).
              Include(n => n.EnquiryProducts).ThenInclude(c => c.Product).
              Include(n => n.EnquiryProducts).ThenInclude(a => a.EnquiryFinanceQuotations).
              Include(n => n.EnquiryExchangeQuotations));

            return enq;

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
            ine.enquiryFinanceQuotations = _unitOfWork.GetRepository<EnquiryFinanceQuotation>().GetList().Items.Where(predicate: x => x.EnquiryProductId == enquiry.Id);

            return ine;
        }

        public async Task<Enquiry> Update(Enquiry enquiry)
        {
            foreach(EnquiryProduct ep in enquiry.EnquiryProducts)
            { 
                foreach(EnquiryFinanceQuotation efq in ep.EnquiryFinanceQuotations)
                {
                    if (_unitOfWork.GetRepository<EnquiryFinanceQuotation>().GetList(predicate: x => x.Id == efq.Id).Count == 0)
                        _unitOfWork.GetRepository<EnquiryFinanceQuotation>().Add(efq);
                }
            }
            _unitOfWork.GetRepository<Enquiry>().Update(enquiry);
            _unitOfWork.SaveChanges();
            return enquiry;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Api.Database.Entity.Threats;
using Api.Domain.Enquiries;
using Threenine.Data;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity;
using Api.Database.Entity.Products;

namespace Swc.Service
{
    public class EnquiriesService : IEnquiriesService
    {
      
        private readonly IUnitOfWork _unitOfWork;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";

        public EnquiriesService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IEnumerable<Enquiry> GetAllActive()
        {
            var enquiries = _unitOfWork.GetRepository<Enquiry>().Get();

          return enquiries;
          
        }
        public InitilizeEnquiry GetInitilizeEnquiries()
        {
            InitilizeEnquiry ie = new InitilizeEnquiry();
            ie.MarketingZones = _unitOfWork.GetRepository<MarketingZone>().Get();
            ie.Products = _unitOfWork.GetRepository<Product>().Get();
            ie.enquiryTypes = _unitOfWork.GetRepository<EnquiryType>().Get();

            return ie;

        }

        public string  Insert(InsertEnquiryModel InsertEnquiries)
        {

            #region  autoMap
            // TODO : Move this to a cache lookup.  We don't want to query on every ADD.
            // TODO :  Expected Volumes could be immense to so we need to optimise 
            //var refType = _unitOfWork.GetRepository<EnquiryType>().Get(x => x.Name == Referer).SingleOrDefault();
            //var status = _unitOfWork.GetRepository<EnquiryStatus>().Get(x => x.Name == Moderate).SingleOrDefault();

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
            var profile = new Profile();
            profile.Name = InsertEnquiries.Enquiry.Name;
            enquiry.Profile = profile;
            enquiry.Identifier = InsertEnquiries.Enquiry.Identifier;

            enquiry.ProfileId = profile.Id;
            enquiry.StatusId=_unitOfWork.GetRepository<EnquiryStatus>()
                .Get(predicate: x => x.ProgrammerId==100).First().Id;
            enquiry.EnquiryTypeId = _unitOfWork.GetRepository<EnquiryType>()
           .Get(predicate: x => x.ProgrammerId == 100).First().Id;
            _unitOfWork.GetRepository<Profile>().Add(profile);
            _unitOfWork.GetRepository<Enquiry>().Add(enquiry);
            //_unitOfWork.GetRepository<EnquiryStatus>().Add(enquirystatus);
            //_unitOfWork.GetRepository<EnquiryType>().Add(enquirytype);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return InsertEnquiries.Enquiry.Identifier;

        }

        public Enquiries GetEnquiries(string identifier)
        {
            //var enquiry = _unitOfWork.GetRepository<Enquiry>().Get(x => x.Identifier == identifier).SingleOrDefault();
            //return Mapper.Map<Enquiries>(enquiry);
            return null;
        }
    }
}

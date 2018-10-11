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
            var enquiries = _unitOfWork.GetRepository<Enquiry>().GetList().Items;

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

        public async Task<string> Insert(InsertEnquiryModel InsertEnquiries)
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
            var profile = new Profile();
            profile.Name = InsertEnquiries.Enquiry.Name;
            enquiry.Profile = profile;
            enquiry.Identifier = InsertEnquiries.Enquiry.Identifier;

            enquiry.ProfileId = profile.Id;
            enquiry.StatusId=_unitOfWork.GetRepository<EnquiryStatus>()
                .GetList().Items.Where(predicate: x => x.ProgrammerId==100).First().Id;
            enquiry.EnquiryTypeId = _unitOfWork.GetRepository<EnquiryType>()
           .GetList().Items.Where(predicate: x => x.ProgrammerId == 100).First().Id;
            _unitOfWork.GetRepository<Profile>().Add(profile);
            _unitOfWork.GetRepository<Enquiry>().Add(enquiry);
            foreach(EnquiryProduct ep in InsertEnquiries.EnquiryProducts)
            {
                ep.product = null;
                ep.EnquiryId = enquiry.Id;
            _unitOfWork.GetRepository<EnquiryProduct>().Add(ep);
            }
            foreach(EnquiryFinanceQuotation efq in InsertEnquiries.enquiryFinanceQuotations)
            {
                efq.product = null;
                efq.EnquiryId = enquiry.Id;
                _unitOfWork.GetRepository<EnquiryFinanceQuotation>().Add(efq);
            }
            foreach(EnquiryExchangeQuotation eeq in InsertEnquiries.enquiryExchangeQuotations)
            {
                eeq.EnquiryId = enquiry.Id;
                _unitOfWork.GetRepository<EnquiryExchangeQuotation>().Add(eeq);
            }


           
                 _unitOfWork.SaveChanges();
           
            return InsertEnquiries.Enquiry.Identifier;

        }

        public Enquiries GetEnquiries(string identifier)
        {
            //var enquiry = _unitOfWork.GetRepository<Enquiry>().GetList(x => x.Identifier == identifier).SingleOrDefault();
            //return Mapper.Map<Enquiries>(enquiry);
            return null;
        }
    }
}

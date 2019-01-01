using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Database.Entity.Enquiries;
using Api.Domain.Enquiries;
using Api.Domain.Paging;

namespace Swc.Service
{
    public interface IEnquiriesService
    {
        Threenine.Data.Paging.IPaginate<Enquiry> GetAllActive(PagingParams pagingParams);
       
        InitilizeEnquiry GetInitilizeEnquiries();
        Task<Enquiry> Insert(InsertEnquiryModel enquiries);
        Task<Enquiry> Update(Enquiry enquiry);
        Enquiry GetEnquiries(string identifier);
        MultiEnquiryModel GetMultiEnquiries(string identifier);

    }
}
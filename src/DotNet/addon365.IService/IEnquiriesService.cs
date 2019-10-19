using addon365.Database.Entity.Enquiries;
using addon365.Domain.Entity.Enquiries;
using addon365.Domain.Entity.Paging;
using System.Threading.Tasks;

namespace addon365.IService
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
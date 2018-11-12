using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Database.Entity.Enquiries;
using Api.Domain.Enquiries;

namespace Swc.Service
{
    public interface IEnquiriesService
    {
        IEnumerable<Enquiries> GetAllActive();
        InitilizeEnquiry GetInitilizeEnquiries();
        Task<string> Insert(InsertEnquiryModel enquiries);
        InsertEnquiryModel GetEnquiries(string identifier);
        MultiEnquiryModel GetMultiEnquiries(string identifier);

    }
}
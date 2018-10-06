using System.Collections.Generic;
using Api.Database.Entity.Enquiries;
using Api.Domain.Enquiries;

namespace Swc.Service
{
    public interface IEnquiriesService
    {
        IEnumerable<Enquiry> GetAllActive();
        InitilizeEnquiry GetInitilizeEnquiries();
        string Insert(InsertEnquiryModel enquiries);
        Enquiries GetEnquiries(string identifier);

    }
}
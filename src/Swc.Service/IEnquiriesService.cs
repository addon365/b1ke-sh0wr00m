using System.Collections.Generic;
using Api.Database.Entity.Enquiries;
using Api.Domain.Enquiries;

namespace Swc.Service
{
    public interface IEnquiriesService
    {
        IEnumerable<Enquiry> GetAllActive();
        string Insert(Enquiries enquiries);
        Enquiries GetEnquiries(string identifier);

    }
}
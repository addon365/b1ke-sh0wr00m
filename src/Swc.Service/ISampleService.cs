using System.Collections.Generic;
using Api.Domain.Enquiries;

namespace Swc.Service
{
    public interface ISampleService
    {
        IEnumerable<Enquiries> GetAllActive();
        string Insert(Enquiries referrer);
        Enquiries GetReferer(string identifier);

    }
}
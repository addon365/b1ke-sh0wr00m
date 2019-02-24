using System.Collections.Generic;
using addon365.Domain.Entity.Enquiries;

namespace addon365.Database.Service
{
    public interface ISampleService
    {
        IEnumerable<Enquiries> GetAllActive();
        string Insert(Enquiries referrer);
        Enquiries GetReferer(string identifier);

    }
}
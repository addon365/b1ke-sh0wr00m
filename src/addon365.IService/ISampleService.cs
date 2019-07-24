using addon365.Domain.Entity.Enquiries;
using System.Collections.Generic;

namespace addon365.IService
{
    public interface ISampleService
    {
        IEnumerable<Enquiries> GetAllActive();
        string Insert(Enquiries referrer);
        Enquiries GetReferer(string identifier);

    }
}
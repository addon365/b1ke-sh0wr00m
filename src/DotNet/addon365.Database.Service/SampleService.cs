using addon365.Domain.Entity.Enquiries;
using addon365.IService;
using System.Collections.Generic;

namespace addon365.Database.Service
{
    public class SampleService : ISampleService
    {


        public SampleService()
        {

        }
        public IEnumerable<Enquiries> GetAllActive()
        {

            return null;
        }

        public string Insert(Enquiries enquiries)
        {
            return null;
        }

        public Enquiries GetReferer(string identifier)
        {
            return null;
        }
    }
}

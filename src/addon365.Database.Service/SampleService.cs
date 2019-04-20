using System;
using System.Collections.Generic;
using System.Linq;
using addon365.Database.Entity.Threats;
using addon365.Domain.Entity.Enquiries;
using Threenine.Data;
using AutoMapper;
using addon365.Database.Entity.Enquiries;
using addon365.IService;

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

        public string  Insert(Enquiries enquiries)
        {
            return null;
        }

        public Enquiries GetReferer(string identifier)
        {
            return null;
        }
    }
}

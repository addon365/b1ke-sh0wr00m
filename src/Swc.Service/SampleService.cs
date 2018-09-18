using System;
using System.Collections.Generic;
using System.Linq;
using Api.Database.Entity.Threats;
using Api.Domain.Enquiries;
using Threenine.Data;
using AutoMapper;
using Api.Database.Entity.Enquiries;

namespace Swc.Service
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

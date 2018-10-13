using Api.Database.Entity.Enquiries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swc.Service
{
   public interface IEnquiryTypeService
    {
        IEnumerable<EnquiryType> GetAllEnquiryType();
        int Insert(EnquiryType enquiryType);
        EnquiryType GetEnquiryType(int programmerId);
        void Delete(EnquiryType enquiryType);
    }
}

using addon365.Database.Entity.Enquiries;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.IService
{
   public interface IEnquiryTypeService
    {
        IEnumerable<EnquiryType> GetAllEnquiryType();
        int Insert(EnquiryType enquiryType);
        EnquiryType GetEnquiryType(int programmerId);
        void Delete(EnquiryType enquiryType);
    }
}

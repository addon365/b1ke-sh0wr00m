using addon365.Database.Entity.Enquiries;
using System.Collections.Generic;

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

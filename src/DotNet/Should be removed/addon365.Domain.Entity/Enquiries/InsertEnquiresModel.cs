using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Enquiries;
using System.Collections.Generic;

namespace addon365.Domain.Entity.Enquiries
{
    public class InsertEnquiryModel
    {
        public Enquiry Enquiry { get; set; }
        public IList<EnquiryCatalogItem> EnquiryItems { get; set; }
        public IEnumerable<EnquiryExchangeQuotation> enquiryExchangeQuotations { get; set; }
        public IEnumerable<EnquiryAccessories> enquiryAccessories { get; set; }
    }
    public class MultiEnquiryModel
    {
        public IEnumerable<Enquiry> enquiries { get; set; }
        public IEnumerable<Contact> contacts { get; set; }
        public IEnumerable<DomainEnquiryProduct> EnquiryItems { get; set; }
        public IEnumerable<EnquiryFinanceQuotation> enquiryFinanceQuotations { get; set; }
        public IEnumerable<EnquiryExchangeQuotation> enquiryExchangeQuotations { get; set; }
        public IEnumerable<EnquiryAccessories> enquiryAccessories { get; set; }
    }
}

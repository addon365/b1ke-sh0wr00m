using addon365.Database.Entity;
using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Enquiries;
using addon365.Database.Entity.Inventory.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.Enquiries
{
    public class InsertEnquiryModel
    {
        public Enquiry Enquiry {get;set;}
        public IList<EnquiryProduct> EnquiryProducts { get; set; }
        public IEnumerable<EnquiryExchangeQuotation> enquiryExchangeQuotations { get; set; }
        public IEnumerable<EnquiryAccessories> enquiryAccessories { get; set; }
    }
    public class MultiEnquiryModel
    {
        public IEnumerable<Enquiry> enquiries { get; set; }
        public IEnumerable<Contact> contacts { get; set; }
        public IEnumerable<DomainEnquiryProduct> EnquiryProducts { get; set; }
        public IEnumerable<EnquiryFinanceQuotation> enquiryFinanceQuotations { get; set; }
        public IEnumerable<EnquiryExchangeQuotation> enquiryExchangeQuotations { get; set; }
        public IEnumerable<EnquiryAccessories> enquiryAccessories { get; set; }
    }
}

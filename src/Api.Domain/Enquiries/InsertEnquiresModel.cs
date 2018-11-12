using Api.Database.Entity;
using Api.Database.Entity.Crm;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Enquiries
{
    public class InsertEnquiryModel
    {
        public Enquiry Enquiry {get;set;}
        public IEnumerable<EnquiryProduct> EnquiryProducts { get; set; }
        public IEnumerable<EnquiryFinanceQuotation> enquiryFinanceQuotations { get; set; }
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

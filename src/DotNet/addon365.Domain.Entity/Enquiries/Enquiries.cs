using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Enquiries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace addon365.Domain.Entity.Enquiries
{
    public class Enquiries
    {

        public Guid EnquiryId { get; set; }
        public string Identifier { get; set; }
        public DateTime EnquiryDate { get; set; }
        public DateTime Created { get; set; }
        public Contact Contact { get; set; }
        public EnquiryType EnquiryType { get; set; }
        public EnquiryStatus Status { get; set; }
        public IList<EnquiryCatalogItem> EnquiryItems { get; set; }
        public EnquiryCatalogItem FirstItem
        {
            get
            {
                return EnquiryItems.FirstOrDefault();
            }
        }
        public EnquiryFinanceQuotation EnquiryFinanceQuotations { get; set; }
        public EnquiryExchangeQuotation EnquiryExchangeQuotations { get; set; }

    }
}

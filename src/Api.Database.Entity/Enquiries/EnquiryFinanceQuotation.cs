using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryFinanceQuotation:BaseEntity
    {
        public string EnquiryId { get; set; }
        public string FinanceQuotationId { get; set; }
    }
}

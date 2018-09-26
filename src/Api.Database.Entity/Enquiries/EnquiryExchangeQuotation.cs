using Api.Database.Entity.ExchangeQuotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryExchangeQuotation:BaseEntity
    {
        public Guid EnquiryId { get; set; }
        [ForeignKey("EnquiryId")] public virtual Enquiry enquiry { get; set; }
        public Guid ExchangeQuotationId { get; set; }
        [ForeignKey("ExchangeQuotationId")] public virtual ExchangeQuotation exchangequotation { get; set; }
    }
}

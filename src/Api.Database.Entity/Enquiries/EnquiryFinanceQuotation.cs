using Api.Database.Entity.Products;
using Api.Database.Entity.FinanceQuotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryFinanceQuotation:BaseEntity
    {
        public Guid EnquiryId { get; set; }
        [ForeignKey("EnquiryId")] public virtual Enquiry enquiry { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")] public virtual Product product { get; set; }
        public Guid FinanceQuotationId { get; set; }
        [ForeignKey("FinanceQuotationId")] public virtual FinanceQuotation financequotation { get; set; }
    }
}

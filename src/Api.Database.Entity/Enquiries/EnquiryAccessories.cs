using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryAccessories:BaseEntity
    {
        public Guid EnquiryId { get; set; }
        [ForeignKey("EnquiryId")] public virtual Enquiry enquiry { get; set; }
        public string Identifier { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")] public virtual Product product { get; set; }
        public Guid AccessoriesId { get; set; }
    }
}

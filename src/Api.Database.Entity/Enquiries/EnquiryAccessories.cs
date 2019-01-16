using Api.Database.Entity.Inventory.Products;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryAccessories:BaseEntityWithLogFields
    {
        public Guid EnquiryId { get; set; }
        [ForeignKey("EnquiryId")] public virtual Enquiry enquiry { get; set; }
       
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")] public virtual Product product { get; set; }
        public Guid AccessoriesId { get; set; }
    }
}

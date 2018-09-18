using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Api.Database.Entity.Products;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryProduct:BaseEntity
    {
        public int EnquiryId { get; set; }
        public int ProductId { get; set; }
        public double OnRoadPrice { get; set; }
        public double AccessoriesAmount { get; set; }
        public double TotalAmount { get; set; }
        [ForeignKey("ProductId")] public virtual Product product { get; set; }
         
    }
}

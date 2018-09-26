using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Products
{
    public class ExtraFittingsAccessories:BaseEntity
    {
        public Guid ProductId{ get; set; }
        [ForeignKey("ProductId")] public virtual Product product { get; set; }
        public Guid AccessoriesProductId { get; set; }
        //[ForeignKey("AccessoriesProductId")] public virtual Product accessoriesproduct { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.ExtraFittingsAccessories")]
    public class ExtraFittingsAccessories:BaseEntityWithLogFields
    {
        public Guid ProductId{ get; set; }
        [ForeignKey("ProductId")] public virtual Product Product { get; set; }
        public Guid AccessoriesProductId { get; set; }
        public virtual Product AccessoriesProductItem { get; set; }
        public double Unit { get; set; }
        public double UnitPrice { get; set; }
        public virtual double Amount { get; set; }
            
        

        //[ForeignKey("AccessoriesProductId")] public virtual Product accessoriesproduct { get; set; }
    }
}

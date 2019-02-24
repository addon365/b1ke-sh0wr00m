using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Sales
{

    [Table("Inventory.Sales.SalesItemsProperties")]
    public class SaleItemProperty:BaseEntity
    {
        public Guid SalesItemsId { get; set; }
        public Guid ProductPropertyMasterId { get; set; }
        public string Value { get; set; }
        public Guid GroupId { get; set; }
    }
}

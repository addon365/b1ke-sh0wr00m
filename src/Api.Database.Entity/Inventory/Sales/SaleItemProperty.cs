using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Sales
{

    [Table("Inventory.Sales.SaleItemProperty")]
    public class SaleItemProperty:BaseEntity
    {
        public Guid SalesItemsId { get; set; }
        public Guid ProductPropertyMasterId { get; set; }
        public string Value { get; set; }
        public Guid GroupId { get; set; }
    }
}

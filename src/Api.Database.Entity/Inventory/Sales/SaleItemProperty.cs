using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Inventory.Sales
{
    public class SaleItemProperty:BaseEntity
    {
        public Guid SalesItemsId { get; set; }
        public Guid ProductPropertyMasterId { get; set; }
        public string Value { get; set; }
        public Guid GroupId { get; set; }
    }
}

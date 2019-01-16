using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Inventory.Products
{
    public class ProductType : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public int ProgrammerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.Product")]
    public class Product:BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double InsuranceAmount { get; set; }
        public double RoadTax { get; set; }
        public string HSN { get; set; }
        public double GST { get; set; }
        public Guid CompanyId { get; set; }
        public Guid TypeId { get; set; }
        public ICollection<ProductPropertiesMap> Properties { get; set; }
    }
}

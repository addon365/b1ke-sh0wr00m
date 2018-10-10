using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Database.Entity.Products
{
    public class Product:BaseEntity
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
    }
}

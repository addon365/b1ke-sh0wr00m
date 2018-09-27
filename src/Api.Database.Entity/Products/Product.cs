using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Products
{
    public class Product:BaseEntity
    {
        public string Identifier { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Guid CompanyId { get; set; }
    }
}

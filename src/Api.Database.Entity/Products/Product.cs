using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Database.Entity.Products
{
    public class Product:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Identifier { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}

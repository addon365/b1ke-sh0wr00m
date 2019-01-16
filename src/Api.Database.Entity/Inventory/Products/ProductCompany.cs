using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Inventory.Products
{
    public class ProductCompany:BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string CompanyName { get; set; }
        public int ProgrammerID { get; set; }
    }
}

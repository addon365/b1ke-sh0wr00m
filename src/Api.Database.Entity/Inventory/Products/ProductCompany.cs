using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.ProductsCompanies")]
    public class ProductCompany:BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string CompanyName { get; set; }
        public int ProgrammerID { get; set; }
    }
}

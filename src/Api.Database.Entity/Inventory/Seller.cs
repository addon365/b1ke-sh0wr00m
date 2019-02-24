using addon365.Database.Entity.Crm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory
{
    [Table("Inventory.Sellers")]
    public class Seller:BaseEntityWithLogFields
    {
        public string SellerId { get; set; }
        public Guid BusinessContactId { get; set; }
        [ForeignKey("BusinessContactId")] public virtual BusinessContact BusinessContact { get; set; }
        public Guid? UserId { get; set; }
    }
}

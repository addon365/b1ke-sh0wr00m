using addon365.Database.Entity.Crm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory
{
    [Table("Inventory.Buyers")]
    public class Buyer:BaseEntityWithLogFields
    {
        public string BuyerId { get; set; }
        public Guid BusinessContactId { get; set; }
        [ForeignKey("BusinessContactId")] public virtual BusinessContact BusinessContact { get; set; }
        public Guid? UserId { get; set; }
    }
}

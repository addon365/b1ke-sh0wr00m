using Api.Database.Entity.Crm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory
{
    [Table("Inventory.Buyer")]
    public class Buyer:BaseEntityWithLogFields
    {
        public string BuyerId { get; set; }
        public Guid BusinessContactId { get; set; }
        [ForeignKey("BusinessContactId")] public virtual BusinessContact BusinessContact { get; set; }
        public Guid? UserId { get; set; }
    }
}

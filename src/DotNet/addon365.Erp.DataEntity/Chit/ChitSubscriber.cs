using addon365.Database.Entity.Crm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Chit
{
    public class ChitSubscriber : BaseEntityWithLogFields
    {
        public string SubscribeId { get; set; }
        public Guid ChitSchemeId { get; set; }
        [ForeignKey("ChitSchemeId")]
        public virtual ChitScheme ChitSchema { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime JoinedDate { get; set; }
        public Guid ClosedVoucherId { get; set; }
    }
}

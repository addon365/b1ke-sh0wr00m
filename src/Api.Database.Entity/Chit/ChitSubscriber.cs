using Api.Database.Entity.Accounts;
using Api.Database.Entity.Crm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Chit
{
    public class ChitSubscriber : BaseEntityWithLogFields
    {
        public string SubscribeId { get; set; }
        public Guid ChitSchemeId { get; set; }
        [ForeignKey("ChitSchemeId")]
        public virtual ChitScheme ChitSchema { get; set; }
        public Customer Customer { get; set; }
        public DateTime JoinedDate { get; set; }
        public VoucherInfo ClosedVoucherInfoId { get; set; }
    }
}

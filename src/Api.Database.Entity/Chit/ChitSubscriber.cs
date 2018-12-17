using Api.Database.Entity.Accounts;
using Api.Database.Entity.Crm;
using System;

namespace Api.Database.Entity.Chit
{
    public class ChitSubscriber : BaseEntity
    {
        public string SubscribeId { get; set; }
        public ChitSchema ChitSchema { get; set; }
        public Customer Customer { get; set; }
        public DateTime JoinedDate { get; set; }
        public VoucherInfo ClosedVoucherInfoId { get; set; }
    }
}

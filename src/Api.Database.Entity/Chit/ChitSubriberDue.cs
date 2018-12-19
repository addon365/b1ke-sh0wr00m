using Api.Database.Entity.Accounts;

namespace Api.Database.Entity.Chit
{
    public class ChitSubriberDue : BaseEntity
    {
        public ChitSubscriber ChitSubscriber { get; set; }
        public string DueNo { get; set; }
        public VoucherInfo VoucherInfo { get; set; }
    }
}

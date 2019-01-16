using Api.Database.Entity.Accounts;

namespace Api.Database.Entity.Chit
{
    public class ChitSubriberDue : BaseEntityWithLogFields
    {
        public ChitSubscriber ChitSubscriber { get; set; }
        public string DueNo { get; set; }
        public VoucherInfo VoucherInfo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Accounts
{
    [Table("Accounts.PaymentModes")]
    public class PaymentMode : BaseEntityWithLogFields
    {
        public string Name { get; set; }
        public string ProgrammerId { get; set; }
    }
}

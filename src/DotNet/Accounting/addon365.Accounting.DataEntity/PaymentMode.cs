using addon365.Common.DataEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Accounting.DataEntity
{
    [Table("Accounting.PaymentModes")]
    public class PaymentMode : BaseEntityWithLogFields
    {
        public string Name { get; set; }
        public string ProgrammerId { get; set; }
    }
}

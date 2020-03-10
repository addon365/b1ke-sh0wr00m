using addon365.Common.DataEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity.Address
{
    [Table("Crm.Address.Pincodes")]
    public class PincodeTable : BaseEntity
    {
        public long Pincode { get; set; }
    }
}

using addon365.Common.DataEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity.Address
{
    [Table("Crm.Address.Districts")]
    public class DistrictTable : BaseEntity
    {
        public string DistrictName { get; set; }

        public string Code { get; set; }
    }
}

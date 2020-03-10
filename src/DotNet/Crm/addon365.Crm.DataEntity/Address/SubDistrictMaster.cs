using addon365.Common.DataEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity.Address
{
    [Table("Crm.Address.SubDistricts")]
    public class SubDistrictTable : BaseEntity
    {
        public string SubDistrictName { get; set; }

        public string Code { get; set; }
    }
}

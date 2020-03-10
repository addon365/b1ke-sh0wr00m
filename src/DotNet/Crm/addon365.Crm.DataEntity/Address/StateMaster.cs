using addon365.Common.DataEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity.Address
{
    [Table("Crm.Address.States")]
    public class StateTable : BaseEntity
    {
        public string StateName { get; set; }

        public string Code { get; set; }
    }
}

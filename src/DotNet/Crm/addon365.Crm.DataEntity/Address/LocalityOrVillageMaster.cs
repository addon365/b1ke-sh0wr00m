using addon365.Common.DataEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity.Address
{
    [Table("Crm.Address.LocalityOrVillages")]
    public class LocalityOrVillageTable : BaseEntity
    {
        public string LocalityOrVillageName { get; set; }


    }
}

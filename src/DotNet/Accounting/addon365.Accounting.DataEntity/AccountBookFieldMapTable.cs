using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Accounting.DataEntity
{
    [Table("Accounting.AccountBookFieldMaps")]
    public class AccountBookFieldMapTable:BaseEntityWithLogFields
    {
        public string FieldNameKey { get; set; }
        public Guid AccountBookKeyId { get; set; }
        [ForeignKey("AccountBookKeyId")]
        public AccountBookTable AccountBookTable{ get; set; }
   
    }
}

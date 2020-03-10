using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Accounts.DataEntity
{
    [Table("Accounts.AccountBookFieldMaps")]
    public class AccountBookFieldMapTable:BaseEntityWithLogFields
    {
        public string FieldNameKey { get; set; }
        public Guid AccountBookKeyId { get; set; }
        [ForeignKey("AccountBookKeyId")]
        public AccountBookTable AccountBookTable{ get; set; }
   
    }
}

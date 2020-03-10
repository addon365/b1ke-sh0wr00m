using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Accounts.DataEntity
{
    [Table("Accounts.VoucherTypes")]
    public class VoucherTypeTable
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public string ProgrammerId { get; set; }
        public VoucherTypeTable()
        {
            this.Id = Guid.NewGuid();
        }

    }
    public enum VoucherTypeMasterEnum { Receipt, Payment, Contra, Purchase, Sales }
}

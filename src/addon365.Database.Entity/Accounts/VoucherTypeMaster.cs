using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace addon365.Database.Entity.Accounts
{
    public class VoucherTypeMaster
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public string ProgrammerId { get; set; }
        public VoucherTypeMaster()
        {
            this.Id = Guid.NewGuid();
        }

    }
    public enum VoucherTypeMasterEnum { Receipt,Payment,Contra,Purchase,Sales}
}

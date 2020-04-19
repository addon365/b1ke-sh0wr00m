using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Common.DataEntity.Privilage
{
    public class BranchPrivilageTable:BaseEntity
    {
        public Guid BusinessPrivilageKeyId { get; set; }
        public string CurrentValue { get; set; }
        public string DefaultValue { get; set; }
        public String ValueOptions { get; set; }
    }
}

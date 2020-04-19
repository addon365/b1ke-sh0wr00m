using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Common.DataEntity.Privilage
{
    public class UserRolePrivilageTable:BaseEntity
    {
        public Guid BusinessPrivilageKeyId { get; set; }
        public string CurrentValue { get; set; }
    }
}

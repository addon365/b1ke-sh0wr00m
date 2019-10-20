using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Entity.Permission
{
    public class UserPermission:BaseEntityWithLogFields
    {
        public Guid UserId { get; set; }

        public Guid LogicId { get; set; }

        public bool Create { get; set; }

        public bool Update { get; set; }
        public bool View { get; set; }

        public bool Delete { get; set; }
    }
}

using System;

namespace addon365.Database.Entity.Permission
{
    public class RolePermission : BaseEntityWithLogFields
    {
        public Guid GroupId { get; set; }

        public Guid LogicId { get; set; }



        public bool Create { get; set; }

        public bool Update { get; set; }
        public bool View { get; set; }

        public bool Delete { get; set; }

    }
}

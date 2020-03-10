using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Common.DataEntity
{
    [Table("User.UserRoleGroups")]
    public class UserRoleGroupTable : BaseEntityWithLogFields
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

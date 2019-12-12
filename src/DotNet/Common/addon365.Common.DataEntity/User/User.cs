using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Common.DataEntity
{
    [Serializable]
    public class User : BaseEntity
    {
        public int OtherId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }

        public virtual string SessionToken { get; set; }

        [NotMapped]
        public string LicenseId { get; set; }

        [NotMapped]
        public string DeviceId { get; set; }

        /**
         * Firebase notification token
         */
        public string NotificationToken { get; set; }

        public Guid? RoleGroupId { get; set; }
        [ForeignKey("RoleGroupId")]
        public RoleGroupMaster RoleGroup { get; set; }
    }
}

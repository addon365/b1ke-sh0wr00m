using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Users
{
    [Serializable]
    public class User:BaseEntity 
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

    }
}

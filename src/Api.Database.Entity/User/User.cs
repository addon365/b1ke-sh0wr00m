﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.User
{
    [Serializable]
    public class User 
    {
        [Key]
        public UInt16 Id { get; set; }
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

﻿namespace Api.Database.Entity.User
{
    public class User : BaseEntity
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
    }
}

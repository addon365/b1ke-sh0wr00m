using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.User
{
    class User
    {
        string UserId { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        string UserName { get; set; }
    }
}

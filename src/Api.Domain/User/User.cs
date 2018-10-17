using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.User
{
    class User
    {
        string UserId { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        string UserName { get; set; }
    }
}

using Api.Database.Entity.User;
using System.Collections.Generic;

namespace Swc.Service
{
    public interface IUserService
    {
        User Validate(string userId, string password);
        User InsertUser(User user);
        IEnumerable<User> GetUsers();
    }
}

using addon365.Database.Entity.Users;
using System.Collections.Generic;

namespace addon365.IService
{
    public interface IUserService
    {
        User Validate(string userId, string password);
        User InsertUser(User user);
        IEnumerable<User> GetUsers();

        User FindUser(string userId);
    }
}

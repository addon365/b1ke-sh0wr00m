using addon365.Database.Entity.User;
using System.Collections.Generic;

namespace addon365.IService
{
    public interface IUserService
    {
        User Validate(string userId, string password);
        User InsertUser(User user);
        IEnumerable<User> GetUsers();
    }
}

using addon365.Database.Entity.Users;
using System;
using System.Collections.Generic;

namespace addon365.IService
{
    public interface IUserService
    {
        User Validate(string userId, string password);
        User InsertUser(User user);
        IEnumerable<User> GetUsers();
        string ChangePassword(Guid id, string oldPassword, string newPassword);
        User FindUser(string userId);

        User UpdateToken(Guid userId, string token);

        string GetToken(Guid userId);


        User Find(Guid id);




    }
}

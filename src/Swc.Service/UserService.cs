using Api.Database.Entity.User;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Threenine.Data;
using System.Linq;

namespace Swc.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Validate(string userId, string password)
        {
            User user = FindUser(userId);
            if (user == null)
                return null;

            byte[] salt = Convert.FromBase64String(user.ConfirmPassword);
            string hashed = generateHash(password, salt);
            if (hashed.CompareTo(user.Password) != 0)
                return null;

            return user;

        }
        public User InsertUser(User user)
        {
            User tmpUser = FindUser(user.UserId);
            if (tmpUser != null)
                return null;
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            user.ConfirmPassword = Convert.ToBase64String(salt);
            user.Password = generateHash(user.Password, salt);
            _unitOfWork.GetRepository<User>().Add(user);
            _unitOfWork.SaveChanges();
            return user;
        }
        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.GetRepository<User>().GetList().Items;
        }

        private User FindUser(string userId)
        {
            IRepository<User> repository = _unitOfWork.GetRepository<User>();
            var users = repository.GetList(predicate: x => x.UserId.CompareTo(userId) == 0).Items;
            User user = null;
            if (users.Count() > 0)
            {
                user = users[0];
            }
            if (user == null)
                return null;
         
            return user;
        }
        private string generateHash(string password, byte[] salt)
        {
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}

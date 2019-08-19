using addon365.Database.Entity.Users;
using addon365.IService;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Threenine.Data;

namespace addon365.Database.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Confirm Password represents Salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        private string GetHash(string password, string confirmPassword)
        {
            byte[] salt = Convert.FromBase64String(confirmPassword);
            string hashed = GenerateHash(password, salt);
            return hashed;
        }
        public User Validate(string userId, string password)
        {
            User user = FindUser(userId);
            if (user == null)
                return null;

            string hashed = GetHash(password, user.ConfirmPassword);
            if (hashed.CompareTo(user.Password) != 0)
                return null;

            return user;

        }
        private byte[] CreateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        public User InsertUser(User user)
        {
            User tmpUser = FindUser(user.UserId);
            if (tmpUser != null)
                return null;
            byte[] salt = CreateSalt();
            user.ConfirmPassword = Convert.ToBase64String(salt);
            user.Password = GenerateHash(user.Password, salt);
            _unitOfWork.GetRepository<User>().Add(user);
            _unitOfWork.SaveChanges();
            return user;
        }
        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.GetRepository<User>().GetList().Items;
        }
      
        public User FindUser(string userId)
        {
            IRepository<User> repository = _unitOfWork
                .GetRepository<User>();
            var users = repository.GetList(
                predicate:
                x => x.UserId.CompareTo(userId) == 0,
                include: x => x.Include(r => r.RoleGroup)
                )
                .Items;
            if (users.Count == 0)
                return null;

            return users[0];
        }
        private string GenerateHash(string password, byte[] salt)
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
        public User Find(Guid id)
        {
            IRepository<User> repository = _unitOfWork
               .GetRepository<User>();
            IList<User> users = repository
                .GetList(predicate: u => u.Id == id,
                include: x => x.Include(r => r.RoleGroup)
                ).Items;
            if (users.Count == 0)
                return null;
            return users[0];
        }
        public User UpdateToken(Guid userId, string token)
        {
            IRepository<User> repository = _unitOfWork
               .GetRepository<User>();
            User user = Find(userId);
            if (user == null)
                return null;
            repository.Update(user);
            user.NotificationToken = token;
            _unitOfWork.SaveChanges();
            return user;
        }
        public string GetToken(Guid userId)
        {
            IRepository<User> repository = _unitOfWork
               .GetRepository<User>();
            IList<User> users = repository
                .GetList(predicate: u => u.Id == userId)
                .Items;
            if (users.Count == 0)
                return null;

            return users[0].NotificationToken;

        }

        public string ChangePassword(Guid id, string oldPassword, string newPassword)
        {
            IRepository<User> repository = _unitOfWork
               .GetRepository<User>();
            var users = repository.GetList(predicate: u => u.Id == id).Items;
            if (users == null || users.Count == 0)
            {
                return "User not found";
            }

            User user = users[0];
            string oldPasswordHash = GetHash(oldPassword, user.ConfirmPassword);
            if (oldPasswordHash.CompareTo(user.Password) != 0)
                return "Invalid password";
            byte[] salt = CreateSalt();
            string newPassHash = GenerateHash(newPassword, salt);
            user.ConfirmPassword = Convert.ToBase64String(salt);
            user.Password = newPassHash;
            repository.Update(user);
            _unitOfWork.SaveChanges();
            return null;


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirBench.Models;

namespace AirBench.Data.Repositories
{
    using BCrypt.Net;

    public class AccountRepository : IAccountRepository
    {
        private IBenchContext _context;

        public AccountRepository(IBenchContext context)
        {
            _context = context;
        }

        public bool Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Add(User entity, string password)
        {
            var hashedPassword = BCrypt.HashPassword(password);
            entity.HashedPassword = hashedPassword;

            try
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Authenticate(string username, string password)
        {
            var user = Get(username);
            if (user == null)
            {
                return false;
            }
            else
            {
                return BCrypt.Verify(password, user.HashedPassword);
            }
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(string username)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Username == username);
            return user;
        }

        public List<User> List()
        {
            throw new NotImplementedException();
        }

        public List<User> ListSimple()
        {
            throw new NotImplementedException();
        }
    }
}
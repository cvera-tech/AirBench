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
            try
            {
                var user = _context.Users
                    .Single(u => u.Username == username);
                return user;
            }
            catch
            {
                return null;
            }
        }

        public List<User> List()
        {
            throw new NotImplementedException();
        }
    }
}
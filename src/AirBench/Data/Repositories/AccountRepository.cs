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
            var user = _context.Users
                .Single(u => u.Username == username);
            return BCrypt.Verify(password, user.HashedPassword);
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> List()
        {
            throw new NotImplementedException();
        }
    }
}
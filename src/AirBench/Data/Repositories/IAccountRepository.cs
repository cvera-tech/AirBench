using AirBench.Models;

namespace AirBench.Data.Repositories
{
    public interface IAccountRepository : IRepository<User>
    {
        bool Add(User entity, string password);
        bool Authenticate(string username, string password);
        User Get(string username);
    }
}
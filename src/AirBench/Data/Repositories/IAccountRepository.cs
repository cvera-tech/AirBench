using AirBench.Models;

namespace AirBench.Data.Repositories
{
    public interface IAccountRepository : IRepository<User>
    {
        bool Authenticate(string username, string password);
        User Get(string username);
    }
}
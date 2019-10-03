using System.Security.Principal;

namespace AirBench.Security
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; }
        string Username { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
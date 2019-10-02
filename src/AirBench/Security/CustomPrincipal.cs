using System.Security.Principal;

namespace AirBench.Security
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public int Id { get; private set; }

        public IIdentity Identity { get; private set; }

        public string Name { get; private set; }

        public CustomPrincipal(int id, string name)
        {
            
        }

        public bool IsInRole(string role)
        {
            // Change when roles are added
            return true;
        }
    }
}
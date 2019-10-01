using System.ComponentModel.DataAnnotations;

namespace AirBench.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Username}: {FirstName} {LastName}";
        }
    }
}
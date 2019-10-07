using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirBench.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ShortName { get { return $"{FirstName} {LastName.Substring(0, 1)}.";  } }

        public override string ToString()
        {
            return $"[{Id}] {Username}: {FirstName} {LastName}";
        }
    }
}
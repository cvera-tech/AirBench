using System.ComponentModel.DataAnnotations;

namespace AirBench.Models.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
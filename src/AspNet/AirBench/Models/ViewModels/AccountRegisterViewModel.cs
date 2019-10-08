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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
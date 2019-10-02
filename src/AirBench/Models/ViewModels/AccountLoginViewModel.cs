using System.ComponentModel.DataAnnotations;

namespace AirBench.Models.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
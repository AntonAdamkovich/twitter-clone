using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
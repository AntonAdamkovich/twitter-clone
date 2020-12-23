using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
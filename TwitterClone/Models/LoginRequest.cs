using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
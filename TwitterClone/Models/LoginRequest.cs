using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Models
{
    public class LoginRequest
    {
        [FromForm(Name = "username")]
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress]
        public string Username { get; set; }

        [FromForm(Name = "password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Models
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "DateOfBirth is required")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
    }
}
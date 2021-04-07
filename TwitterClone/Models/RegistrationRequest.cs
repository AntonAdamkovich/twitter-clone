using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Models
{
    public class RegistrationRequest
    {
        [FromForm(Name="username")]
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress]
        public string Username { get; set; }

        [FromForm(Name="password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [FromForm(Name="firstName")]
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [FromForm(Name="dateOfBirth")]
        [Required(ErrorMessage = "DateOfBirth is required")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TwitterClone.Models.Database
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [PersonalData]
        public string AuthId { get; set; }
 
        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [PersonalData]
        [DataType(DataType.Url)]
        public Uri ProfileImageUri { get; set; }
    }
}
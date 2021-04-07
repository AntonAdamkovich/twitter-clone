using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterClone.Models.Database
{
    public class Relationship
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public User Follower { get; set; }
        public User Followed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
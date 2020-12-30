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
        [ForeignKey("UserForeignKey")]
        public Guid FollowerId { get; set; }
        [ForeignKey("UserForeignKey")]
        public Guid FollowedId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
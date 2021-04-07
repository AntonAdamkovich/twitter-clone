using Microsoft.EntityFrameworkCore;
using TwitterClone.Models.Database;

namespace TwitterClone.Context
{
    public class TwitterCloneDbContext : DbContext
    {
        public const string ConnectionStringPropertyName = "DefaultDbConnection";

        public TwitterCloneDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
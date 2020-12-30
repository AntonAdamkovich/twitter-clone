using Microsoft.EntityFrameworkCore;
using TwitterClone.Models.Database;

namespace TwitterClone.Context
{
    public class TwitterCloneDbContext : DbContext
    {
        public TwitterCloneDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
            // modelBuilder.Entity<User>()
            //     .Property(b => b.Id)
            //     .ValueGeneratedOnAdd();
        // }
    }
}
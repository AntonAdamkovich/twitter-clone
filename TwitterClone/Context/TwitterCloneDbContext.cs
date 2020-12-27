using Microsoft.EntityFrameworkCore;
using TwitterClone.Models.Database;

namespace TwitterClone.Context
{
    public class TwitterCloneDbContext : DbContext
    {
        public TwitterCloneDbContext(DbContextOptions options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>()
            //     .Property(b => b.Id)
            //     .ValueGeneratedOnAdd();
        }
    }
}
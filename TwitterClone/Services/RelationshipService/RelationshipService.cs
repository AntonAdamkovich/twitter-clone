using System;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Context;
using TwitterClone.Models.Database;

namespace TwitterClone.Services.RelationshipService
{
    public class RelationshipService : IRelationshipService
    {
        private readonly TwitterCloneDbContext _dbContext;

        public RelationshipService(TwitterCloneDbContext context)
        {
            _dbContext = context;
        }

        public async Task CreateRelationshipAsync(User followed, User follower)
        {
            await _dbContext.Relationships.AddAsync(new Relationship
            {
               Followed = followed,
               Follower = follower,
               CreatedAt = DateTime.Now,
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
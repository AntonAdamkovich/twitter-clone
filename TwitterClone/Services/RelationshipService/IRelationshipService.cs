using System.Threading.Tasks;
using TwitterClone.Models.Database;

namespace TwitterClone.Services.RelationshipService
{
    public interface IRelationshipService
    {
        public Task CreateRelationshipAsync(User followed, User follower);
    }
}
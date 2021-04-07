using System.Threading.Tasks;
using TwitterClone.Models;
using TwitterClone.Models.Database;

namespace TwitterClone.Services.TweetService
{
    public interface ITweetService
    {
        public Task<Tweet> CreateTweetAsync(CreateTweetRequest tweetData, User user);
    }
}
using System;
using System.Threading.Tasks;
using TwitterClone.Context;
using TwitterClone.Models;
using TwitterClone.Models.Database;

namespace TwitterClone.Services.TweetService
{
    public class TweetService : ITweetService
    {
        private readonly TwitterCloneDbContext _dbContext;

        public TweetService(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tweet> CreateTweetAsync(CreateTweetRequest tweetData, User user)
        {
            var addingResult = await _dbContext.Tweets.AddAsync(new Tweet
            {
                User = user,
                CreatedAt = DateTime.Now,
                Text = tweetData.Text,
            });

            await _dbContext.SaveChangesAsync();

            return addingResult.Entity;
        }
    }
}
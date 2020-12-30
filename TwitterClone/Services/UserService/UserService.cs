using System;
using System.Threading.Tasks;
using TwitterClone.Context;
using TwitterClone.Models;
using TwitterClone.Models.Database;

namespace TwitterClone.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly TwitterCloneDbContext _dbContext; 

        public UserService(TwitterCloneDbContext context)
        {
            _dbContext = context;
        }

        public async Task<User> CreateUserAsync(RegistrationRequest userData, string authId, Uri profileImageUri)
        {
            var user = new User
            {
                Username = userData.Username,
                FirstName = userData.FirstName,
                LastName = userData.Username,
                DateOfBirth = userData.DateOfBirth,
                AuthId = authId,
                ProfileImageUri = profileImageUri
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
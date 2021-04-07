using System;
using System.Linq;
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

        public async Task<User> FindUserByUsernameAsync(string username)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Username == username);
        }

        public async Task<User> FindUserByAuthIdAsync(string authId)
        {
            return _dbContext.Users.FirstOrDefault(user => user.AuthId == authId);
        }
    }
}
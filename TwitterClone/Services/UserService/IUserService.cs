using System;
using System.Threading.Tasks;
using TwitterClone.Models;
using TwitterClone.Models.Database;

namespace TwitterClone.Services.UserService
{
    public interface IUserService
    {
        public Task<User> CreateUserAsync(RegistrationRequest userData, string authId, Uri profileImageUri);
        public Task<User> FindUserByUsernameAsync(string username);
        public Task<User> FindUserByAuthIdAsync(string authId);
    }
}
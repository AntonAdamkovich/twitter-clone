using System.Threading.Tasks;
using Auth0.AuthenticationApi.Models;
using TwitterClone.Models;

namespace TwitterClone.Services.AuthService
{
    public interface IAuthService
    {
        public Task<SignupUserResponse> SignupUserAsync(RegistrationRequest userdata);
        public Task<AccessTokenResponse> AuthenticateUserAsync(LoginRequest userData);
    }
}
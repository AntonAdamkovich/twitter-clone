using System;
using System.Threading.Tasks;
using TwitterClone.Models;
using Microsoft.Extensions.Configuration;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;

namespace TwitterClone.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly AuthenticationApiClient _authenticationClient;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;

            var domain = new Uri(_configuration.GetValue<string>("Auth:Domain"));
            _authenticationClient = new AuthenticationApiClient(domain);
        }

        public async Task<SignupUserResponse> SignupUserAsync(RegistrationRequest userData)
        {
            var signupUserRequest = new SignupUserRequest
            {
                Email = userData.Username,
                Username = userData.Username,
                Password = userData.Password,
                FamilyName = userData.LastName,
                GivenName = userData.FirstName,
                Name = userData.FirstName,
                ClientId = _configuration.GetValue<string>("Auth:ClientId"),
                Connection = _configuration.GetValue<string>("Auth:Connection"),
            };
            
            return await _authenticationClient.SignupUserAsync(signupUserRequest); 
        }

        public async Task<AccessTokenResponse> AuthenticateUserAsync(LoginRequest userData)
        {
            var authenticateUserRequest = new ResourceOwnerTokenRequest
            {
                Username = userData.Username,
                Password = userData.Password,
                Realm = _configuration.GetValue<string>("Auth:Connection"),
                ClientId = _configuration.GetValue<string>("Auth:ClientId"),
                ClientSecret = _configuration.GetValue<string>("Auth:ClientSecret"),
            };
            return await _authenticationClient.GetTokenAsync(authenticateUserRequest);
        }
    }
}
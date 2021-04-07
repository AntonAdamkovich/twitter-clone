using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TwitterClone.Models;
using Microsoft.Extensions.Configuration;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using System.Text.Json;
using System.Threading;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace TwitterClone.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly AuthenticationApiClient _authenticationClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;

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
                // Audience = "https://twitter-clone-api.dev",
            };
            return await _authenticationClient.GetTokenAsync(authenticateUserRequest);
        }

        public async Task<JwtSecurityToken> ValidateTokenAsync(string token)
        {
            try
            {
                var authDomain = _configuration.GetValue<string>("Auth:Domain");
                var configurationUri = new Uri($"{authDomain}.well-known/openid-configuration");
            
                var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    configurationUri.ToString(),
                    new OpenIdConnectConfigurationRetriever(),
                    new HttpDocumentRetriever());

                var cancellationToken = new CancellationToken();
                var configuration = await configurationManager.GetConfigurationAsync(cancellationToken);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    RequireSignedTokens = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidIssuer = configuration.Issuer,
                    IssuerSigningKeys = configuration.SigningKeys,
                };

                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                
                return validatedToken as JwtSecurityToken;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
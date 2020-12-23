using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Models;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using TwitterClone.Services.AuthService;

namespace TwitterClone.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthorizationController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginRequest userData)
        {
            var tokenResponse = await _authService.AuthenticateUserAsync(userData);

            return Ok();
        }
        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            return Ok();
        }
        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> ChangePassword()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Registration([FromBody]RegistrationRequest userData)
        {
            var user = await _authService.SignupUserAsync(userData);

            return Ok();
        }
    }
}
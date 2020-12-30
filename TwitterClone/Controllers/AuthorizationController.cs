using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterClone.Context;
using TwitterClone.Models;
using TwitterClone.Services.AuthService;
using TwitterClone.Services.UserService;

namespace TwitterClone.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthorizationController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
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
            if (ModelState.IsValid)
            {
                var auth0User = await _authService.SignupUserAsync(userData);
                await _userService.CreateUserAsync(userData, auth0User.Id, new Uri(""));

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
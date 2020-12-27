using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterClone.Context;
using TwitterClone.Models;
using TwitterClone.Services.AuthService;

namespace TwitterClone.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly TwitterCloneDbContext _dbContext;
        public AuthorizationController(IAuthService authService, TwitterCloneDbContext context)
        {
            _authService = authService;
            _dbContext = context;
        }
        
        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginRequest userData)
        {
            var tokenResponse = await _authService.AuthenticateUserAsync(userData);

            return Ok();
        }
        
        [HttpPost]
        // [Authorize]
        public async Task<ActionResult> Logout()
        {
            var users = await _dbContext.Users.ToListAsync();

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
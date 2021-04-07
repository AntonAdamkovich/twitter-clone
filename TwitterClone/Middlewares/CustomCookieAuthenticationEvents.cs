using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TwitterClone.Services.AuthService;
using TwitterClone.Services.UserService;

namespace TwitterClone.Events
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public CustomCookieAuthenticationEvents(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;
            var authenticationClaim = userPrincipal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Authentication);
            var token = await _authService.ValidateTokenAsync(authenticationClaim?.Value);

            if (token == null)
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            else
            {
                
                var user = await _userService.FindUserByAuthIdAsync(token.Subject);
                // await context.HttpContext.SignInAsync();
            }
        }
    }
}
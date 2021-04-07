using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // [AllowAnonymous]
        [Consumes("application/x-www-form-urlencoded")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginResponse>> Login([FromForm]LoginRequest userData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine(HttpContext.User.Identity);
                    var tokenResponse = await _authService.AuthenticateUserAsync(userData);
                    var user = await _userService.FindUserByUsernameAsync(userData.Username);

                    if (user == null)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }
                    
                    // create custom cookie with ID token
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Authentication, tokenResponse.IdToken),
                    };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, 
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity));
                    
                    var response = new LoginResponse(user);
            
                    return Ok(response);
                }
                catch (Exception e)
                {
                    // TODO: generate understandable error and log it
                    return StatusCode(StatusCodes.Status500InternalServerError);   
                }
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            return Ok();
        }
        
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ChangePassword()
        {
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes("application/x-www-form-urlencoded")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegistrationResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RegistrationResponse>> Registration([FromForm]RegistrationRequest userData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var auth0User = await _authService.SignupUserAsync(userData);
                    var user = await _userService.CreateUserAsync(userData, auth0User.Id, new Uri("http://mock.com"));
                    var response = new RegistrationResponse(user);

                    return Ok(response);
                }
                catch (Exception)
                {
                    // TODO: generate understandable error and log it
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
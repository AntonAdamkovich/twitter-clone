using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        public AuthorizationController()
        {
        }
        
        [HttpPost]
        public async Task<ActionResult> Login([FromBody()]LoginRequest userData)
        {
            Console.WriteLine(userData);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody()]RegistrationRequest userData)
        {
            return Ok();
        }
    }
}
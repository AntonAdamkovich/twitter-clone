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
        public async Task<ActionResult> Login(LoginRequest userData)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Register()
        {
            return Ok();
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetTweets()
        {
            return Ok(new
            {
                Message = "Hello from a GetTweets."
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddTweet()
        {
            return Ok(new
            {
                Message = "Hello from a AddTweet."
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> EditTweet()
        {
            return Ok(new
            {
                Message = "Hello from a EditTweet."
            });
        }
        
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteTweet()
        {
            return Ok(new
            {
                Message = "Hello from a DeleteTweet."
            });
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }

        public async Task<ActionResult> GetTweets()
        {
            return Ok();
        }

        public async Task<ActionResult> AddTweet()
        {
            return Ok();
        }

        public async Task<ActionResult> EditTweet()
        {
            return Ok();
        }
        
        public async Task<ActionResult> DeleteTweet()
        {
            return Ok();
        }
    }
}
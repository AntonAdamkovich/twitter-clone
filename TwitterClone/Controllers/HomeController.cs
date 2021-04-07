using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Models;
using TwitterClone.Models.Database;
using TwitterClone.Services.CommentService;
using TwitterClone.Services.RelationshipService;
using TwitterClone.Services.TweetService;

namespace TwitterClone.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IRelationshipService _relationshipService;
        private readonly ITweetService _tweetService;
        private readonly ICommentService _commentService;

        public HomeController(IRelationshipService relationshipService, ITweetService tweetService, ICommentService commentService)
        {
            _relationshipService = relationshipService;
            _tweetService = tweetService;
            _commentService = commentService;
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

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateTweetResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateTweetResponse>> CreateTweet([FromForm] CreateTweetRequest tweetData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tweet = await _tweetService.CreateTweetAsync(tweetData, new User());
                    return Ok(tweet);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest();
            }
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
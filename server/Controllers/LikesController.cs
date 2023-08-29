// LikeController.cs

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    [Route("api/posts/{postId}/likes")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikesService _likeService;

        public LikeController(ILikesService likeService)
        {
            _likeService = likeService;
        }

        // GET: api/posts/{postId}/likes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikesModel>>> GetLikes(int postId)
        {
            var likes = await _likeService.GetLikesByPostId(postId);
            return Ok(likes);
        }
    }
}

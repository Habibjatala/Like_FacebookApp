using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostServices _postServices;
        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }
        // GET: api/post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostModel>>> GetAllPosts()
        {
            var posts = await _postServices.GetAllPosts();
            return Ok(posts);
        }

        // GET: api/post/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostModel>> GetPostById(int id)
        {
            var post = await _postServices.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // GET: api/user/{userId}/posts
        [HttpGet("~/api/user/{userId}/posts")]
        public async Task<ActionResult<IEnumerable<PostModel>>> GetPostsByUserId(int userId)
        {
            var posts = await _postServices.GetPostsByUserId(userId);
            return Ok(posts);
        }
    }
}

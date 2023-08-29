using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;
using testClass.dtos;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser(UserModel user)
        {
            var createdUser = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(LoginDto login)
        {
            var user = await _userService.Login( login);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new { message = "Login successful", user });
        }

        // POST: api/users/{id}/posts
        [HttpPost("{id}/posts")]

        public async Task<IActionResult> AddPost(int id, AddPostDto post)
        {
            var addedPost = await _userService.AddPost(id, post);
            if (addedPost == null)
            {
                return NotFound();
            }

            return Ok(new { id = addedPost.Id }); //CreatedAtAction("GetPost", new { id = addedPost.Id }, addedPost);
        }

        // POST: api/users/{id}/posts/{postId}/comments
        [HttpPost("{id}/posts/{postId}/comments")]

        public async Task<IActionResult> AddComment(int id, int postId, AddComtDto comment)
        {
            try
            {
                var addedComment = await _userService.AddComment(id, postId, comment);
                if (addedComment == null)
                {
                    return NotFound();
                }

                return Ok(new { id = addedComment.Id });//   CreatedAtAction("GetComment", new { id = addedComment.Id }, addedComment);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // POST: api/users/{id}/posts/{postId}/like
        [HttpPost("{id}/posts/{postId}/like")]
        public async Task<IActionResult> LikePost(int id, int postId)
        {
            await _userService.LikePost(id, postId);
            return Ok();
        }

    }
}

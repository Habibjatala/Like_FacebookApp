using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentServices _commentService;

        public CommentController(ICommentServices commentService)
        {
            _commentService = commentService;
        }

        // GET: api/posts/{postId}/comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComments(int postId)
        {
            var comments = await _commentService.GetCommentsByPostId(postId);
            return Ok(comments);
        }
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<CommentModel>>> DeleteCommentsByUserID(int commenterId, int commentId)
        {
            var del = await _commentService.DeleteCommentsByUserID(commenterId,commentId);
            return Ok(del);
        }
    }
}

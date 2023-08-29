// LikeService.cs

using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services
{
    public class LikeService : ILikesService
    {
        private readonly MyDbContext _context;

        public LikeService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetLikesByPostId(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                var totalLikes = post.Likes ?? 0;
                return totalLikes;
            }
            else
            {
                throw new Exception("Post does not exist");
            }
        }
    }
}

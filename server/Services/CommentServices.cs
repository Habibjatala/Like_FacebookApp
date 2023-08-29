using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;

namespace Project2.Services
{
    public class CommentServices:ICommentServices
    {
        private readonly MyDbContext _context;
        public CommentServices(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CommentModel>> GetCommentsByPostId(int postId)
        {
            return await _context.Comments
                .Include(c => c.Commenter)
                .Where(c => c.PostId == postId)
                .ToListAsync();
        }

        public async Task<CommentModel> DeleteCommentsByUserID(int commenterId, int commentId)
        {
            var delcommt = await _context.Comments.FirstOrDefaultAsync(c=> c.CommenterId==commenterId && c.Id==commentId);

            if (delcommt == null)
            {
                throw new Exception("Comment Not found");
                
            }
            _context.Comments.Remove(delcommt);
            _context.SaveChanges();

            return delcommt;
        }
    }
}

using Project2.Models;

namespace Project2.Services
{
    public interface ICommentServices
    {
        Task<IEnumerable<CommentModel>> GetCommentsByPostId(int postId);
        Task<CommentModel> DeleteCommentsByUserID(int commenterId,int commentId);
    }
}

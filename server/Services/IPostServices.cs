using Project2.Models;

namespace Project2.Services
{
    public interface IPostServices
    {
        Task<IEnumerable<PostModel>> GetAllPosts();
        Task<PostModel> GetPostById(int id);
        Task<IEnumerable<PostModel>> GetPostsByUserId(int userId);
    }
}

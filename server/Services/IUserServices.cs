using Project2.Models;
using testClass.dtos;

namespace Project2.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUser(int id);
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> Login(LoginDto login);
        Task<PostModel> AddPost(int userId, AddPostDto post);
        Task<CommentModel> AddComment(int userId, int postId, AddComtDto comment);
        Task LikePost(int userId, int postId);
    }
}

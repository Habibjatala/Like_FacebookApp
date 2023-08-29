using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;
using Project2.Services.Repository;
using testClass.dtos;

namespace Project2.Services
{
    public class UserServices : IUserServices
    {
        private readonly MyDbContext _context;
        private readonly MyRepository<UserModel> _repository;
        private readonly MyRepository<PostModel> _Postrepository;
        //private readonly MyRepository<CommentModel> _Commtrepository;
        public UserServices(MyDbContext db, MyRepository<UserModel> repository, MyRepository<PostModel> postrepository)
        {
            _context = db;
            _repository = repository;
            _Postrepository = postrepository;
            //_Commtrepository = commtrepository;
        }

/// <summary>
/// /////////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

/// //////////////////////////////////////////////

        public async Task<UserModel> GetUser(int id)
        {
            return await _repository.Get(id);
        }

/// //////////////////////////////////////////////


        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _repository.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        ///////////////////////////////////////
        ///
        public async Task<UserModel> Login(LoginDto login)
        {
            try
            {
                var user = await _repository.Login(login);

                if (user == null)
                {
                    throw new Exception("Invalid credentials.");
                }

                // You can perform additional validation here, such as checking the password hash
                // and comparing it with the provided password.

                return user;
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                throw new Exception(ex.Message); // Rethrow the exception to propagate it to the caller
            }
        }

        /// <summary>
        /// ////////////////////////////////////
        /// </summary>

        public async Task<PostModel> AddPost(int userId, AddPostDto post)
        {
            var user= await _Postrepository.AddPost(userId, post);
           
            return user;
        }

        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary>
     
        public async Task<CommentModel> AddComment(int userId, int postId, AddComtDto comment)
        {
            var commt = await _repository.AddComment(userId, postId, comment);
            return commt;
        }

       /// <summary>
       /// ///////////////////////////////////////////////////
       /// </summary>
       
       
        public async Task LikePost(int userId, int postId)
        {
            var user = await _context.Users.FindAsync(userId);
            var post = await _context.Posts.FindAsync(postId);

            if (user != null && post != null && !await _context.Likes.AnyAsync(l => l.UserId == userId && l.PostId == postId))
            {
                post.Likes++;
                _context.Likes.Add(new LikesModel { UserId = userId, PostId = postId });
                await _context.SaveChangesAsync();
            }



        }

    }
}

using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;
using testClass.dtos;

namespace Project2.Services.Repository
{
    public class MyRepository<TEntity> where TEntity : class
    {
        private readonly MyDbContext context;
        public MyRepository(MyDbContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }


        //////////////////////////////////////////////////////
        ///
        public async Task<PostModel> AddPost(int userId, AddPostDto post)
        {
            var user = await context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User is not Existing");
            }

            post.AuthorId = userId;

            var postmodel = new PostModel
            {

                Likes = post.Likes ?? 0,
                Content = post.Content,
                AuthorId = userId,
            };
            context.Posts.Add(postmodel);
            await context.SaveChangesAsync();
            return postmodel;
        }

        /////////////////////////////////////
        ///

        public async Task<UserModel> Login(LoginDto login)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.email == login.email && u.password == login.password);

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

        ///////////////////////////////////////////////////
        ///
        public async Task<CommentModel> AddComment(int userId, int postId, AddComtDto comment)
        {
            var user = await context.Users.FindAsync(userId);
            var post = await context.Posts.FindAsync(postId);
            if (user == null || post == null)
            {
                throw new Exception("User or post does not exist.");
            }

            

            var commentModel = new CommentModel
            {
                Content = comment.Content,
                CommenterId = userId,
                PostId= postId
             
                
            };

            context.Comments.Add(commentModel);
            await context.SaveChangesAsync();
            return commentModel;
        }
       

        public async Task<IEnumerable<PostModel>> GetPostsByUserId(int userId)
        {
            var posts = await context.Posts.Where(p => p.AuthorId == userId).ToListAsync();
            if (posts != null)
            {
                return posts;
            }
            else
            {
                throw new Exception("The user Has No Posts");
            }
        }
    }
}

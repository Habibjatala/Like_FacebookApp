using Microsoft.EntityFrameworkCore;
using Project2.Models;

namespace Project2.Data
{
    public class MyDbContext:DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<LikesModel> Likes { get; set; }



        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
       
    }
}

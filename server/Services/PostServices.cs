using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;
using Project2.Services.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services
{
    public class PostServices :IPostServices
    {
        private readonly MyDbContext _context;
        private readonly MyRepository<PostModel> _Postrepository;

        public PostServices(MyDbContext context, MyRepository<PostModel> postrepository)
        {
            _context = context;
            _Postrepository = postrepository;
        }

        public async Task<IEnumerable<PostModel>> GetAllPosts()
        {
            return await _Postrepository.GetAll();
        }

        public async Task<PostModel> GetPostById(int id)
        {
            return await _Postrepository.Get(id);
        }

        public async Task<IEnumerable<PostModel>> GetPostsByUserId(int userId)
        {
            var posts= await _Postrepository.GetPostsByUserId(userId);
            return posts;
        }
    
}
}

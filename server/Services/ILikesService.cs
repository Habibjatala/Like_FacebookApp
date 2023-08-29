// ILikeService.cs

using Project2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2.Services
{
    public interface ILikesService
    {
        Task<int> GetLikesByPostId(int postId);
    }
}

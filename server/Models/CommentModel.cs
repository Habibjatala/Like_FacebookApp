using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }

        
        public int? CommenterId { get; set; }
        public UserModel Commenter { get; set; }
      public PostModel post { get; set; }
        public int? PostId { get; set; }

     

    }
}

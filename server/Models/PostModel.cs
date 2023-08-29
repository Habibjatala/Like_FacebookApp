namespace Project2.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? Likes { get; set; }
        public UserModel Author { get; set; }
        public int? AuthorId { get; set; }
     

    }
}

namespace Project2.Models
{
    public class LikesModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public virtual UserModel User { get; set; }
        public virtual PostModel Post { get; set; }
    }
}

namespace RealTimeApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
namespace CleanArch.Core.Entities
{
    public class Like
    {
        public Like(int userId, int commentId)
        {
            UserId = userId;
            CommentId = commentId;
            DateCreated = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int CommentId { get; private set; }
        public DateTime DateCreated { get; private set; }
    }
}

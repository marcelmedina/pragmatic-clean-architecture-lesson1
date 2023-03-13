namespace CleanArch.Core.Exceptions
{
    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException(int commentId) : base($"CommentId {commentId} not found.")
        {
        }

        public CommentNotFoundException(int commentId, Exception inner) : base($"CommentId {commentId} not found.", inner)
        {
        }
    }
}

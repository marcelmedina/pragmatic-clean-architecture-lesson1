namespace CleanArch.Core.DTOs
{
    public class SubmitCommentDto
    {
        public int BlogPostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}

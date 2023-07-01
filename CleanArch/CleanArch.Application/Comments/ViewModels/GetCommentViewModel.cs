using CleanArch.Core.Enums;

namespace CleanArch.Application.ViewModels
{
    public class GetCommentViewModel
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public ApprovalStatusEnum Status { get; set; }
    }
}

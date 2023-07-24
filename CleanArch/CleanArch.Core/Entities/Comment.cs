using CleanArch.Core.Enums;

namespace CleanArch.Core.Entities
{
    public class Comment
    {
        public Comment(int blogPostId, int userId, string description)
        {
            BlogPostId = blogPostId;
            UserId = userId;
            Description = description;
            DateCreated = DateTime.UtcNow;
            Status = ApprovalStatusEnum.Submitted;
            Likes = new List<Like>();
        }

        public int Id { get; private set; }
        public int BlogPostId { get; private set; }
        public int UserId { get; private set; }
        public string Description { get; private set; }
        public DateTime DateCreated { get; private set; }
        public ApprovalStatusEnum Status { get; private set; }
        public List<Like> Likes { get; private set; }

        public void Process()
        {
            if (Status == ApprovalStatusEnum.Submitted)
            {
                Status = ApprovalStatusEnum.InProcess;
            }
        }

        public void Approve()
        {
            if (Status == ApprovalStatusEnum.InProcess)
            {
                Status = ApprovalStatusEnum.Approved;
            }
        }

        public void Reject()
        {
            if (Status == ApprovalStatusEnum.InProcess)
            {
                Status = ApprovalStatusEnum.Rejected;
            }
        }

        public void Publish()
        {
            if (Status == ApprovalStatusEnum.Approved)
            {
                Status = ApprovalStatusEnum.Published;
            }
        }
    }
}

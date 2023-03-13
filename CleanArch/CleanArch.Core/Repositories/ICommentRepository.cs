using CleanArch.Core.DTOs;

namespace CleanArch.Core.Repositories
{
    public interface ICommentRepository
    {
        Task<List<GetCommentDto>> GetCommentsAsync();
        Task<GetCommentDto> GetCommentByIdAsync(int commentId);
        Task SubmitCommentAsync(SubmitCommentDto submitCommentDto);
        Task ProcessCommentAsync(int commentId);
        Task ApproveCommentAsync(int commentId);
        Task RejectCommentAsync(int commentId);
        Task PublishCommentAsync(int commentId);
        Task BanUser(int userId);
    }
}

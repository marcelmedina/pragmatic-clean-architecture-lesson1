using CleanArch.Application.InputModels;
using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Services
{
    public interface ICommentService
    {
        Task<List<GetCommentViewModel>> GetCommentsAsync();
        Task<GetCommentViewModel> GetCommentByIdAsync(int commentId);
        Task SubmitCommentAsync(SubmitCommentInputModel submitCommentInputModel);
        Task ProcessCommentAsync(int commentId);
    }
}

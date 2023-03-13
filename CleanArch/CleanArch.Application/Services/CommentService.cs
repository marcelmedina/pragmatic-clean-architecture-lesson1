using CleanArch.Application.InputModels;
using CleanArch.Application.ViewModels;
using CleanArch.Core.Exceptions;
using CleanArch.Core.Repositories;
using CleanArch.Core.Services;

namespace CleanArch.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IContentModerationService _contentModerationService;

        public CommentService(ICommentRepository commentRepository, IContentModerationService contentModerationService)
        {
            _commentRepository = commentRepository;
            _contentModerationService = contentModerationService;
        }

        public async Task<List<GetCommentViewModel>> GetCommentsAsync()
        {
            var comments = await _commentRepository.GetCommentsAsync();

            var commentsViewModel = comments.Select(c => new GetCommentViewModel()
            {
                Id = c.Id,
                BlogPostId = c.BlogPostId,
                UserId = c.UserId,
                DateCreated = c.DateCreated,
                Description = c.Description,
                Status = c.Status
            }).ToList();

            return commentsViewModel;
        }

        public async Task<GetCommentViewModel> GetCommentByIdAsync(int commentId)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(commentId);

            if (comment == null)
            {
                throw new CommentNotFoundException(commentId);
            }

            var commentsViewModel = new GetCommentViewModel()
            {
                Id = comment.Id,
                BlogPostId = comment.BlogPostId,
                UserId = comment.UserId,
                DateCreated = comment.DateCreated,
                Description = comment.Description,
                Status = comment.Status
            };

            return commentsViewModel;
        }

        public Task SubmitCommentAsync(SubmitCommentInputModel submitCommentInputModel)
        {
            throw new NotImplementedException();
        }

        public async Task ProcessCommentAsync(int commentId)
        {
            var comment = await GetCommentByIdAsync(commentId);

            await _commentRepository.ProcessCommentAsync(commentId);

            var hasProfanity = await _contentModerationService.HasProfanity(comment.Description);

            if (hasProfanity)
            {
                // TODO: Transaction
                await _commentRepository.RejectCommentAsync(commentId);
                await _commentRepository.BanUser(comment.UserId);
            }
            else
            {
                await _commentRepository.ApproveCommentAsync(commentId);
            }
        }
    }
}

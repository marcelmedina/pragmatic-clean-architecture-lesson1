using CleanArch.Core.DTOs;
using CleanArch.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CommentDbContext _commentDbContext;

        public CommentRepository(CommentDbContext commentDbContext)
        {
            _commentDbContext = commentDbContext;
        }

        public async Task<List<GetCommentDto>> GetCommentsAsync()
        {
            var comments = await _commentDbContext.Comments.ToListAsync();
            var commentsDto = comments.Select(c => new GetCommentDto()
            {
                Id = c.Id,
                UserId = c.UserId,
                BlogPostId = c.BlogPostId,
                DateCreated = c.DateCreated,
                Description = c.Description,
                Status = c.Status
            }).ToList();

            return commentsDto;
        }

        public async Task<GetCommentDto> GetCommentByIdAsync(int commentId)
        {
            var comment = await _commentDbContext.Comments.FirstOrDefaultAsync(c => c.Id == commentId);

            if (comment == null)
            {
                return new GetCommentDto();
            }

            return new GetCommentDto()
            {
                Id = comment.Id,
                UserId = comment.UserId,
                BlogPostId = comment.BlogPostId,
                DateCreated = comment.DateCreated,
                Description = comment.Description,
                Status = comment.Status
            };
        }

        public Task SubmitCommentAsync(SubmitCommentDto submitCommentDto)
        {
            return Task.CompletedTask;
        }

        public Task ProcessCommentAsync(int commentId)
        {
            return Task.CompletedTask;
        }

        public Task ApproveCommentAsync(int commentId)
        {
            return Task.CompletedTask;
        }

        public Task RejectCommentAsync(int commentId)
        {
            return Task.CompletedTask;
        }

        public Task PublishCommentAsync(int commentId)
        {
            return Task.CompletedTask;
        }

        public Task BanUser(int userId)
        {
            return Task.CompletedTask;
        }
    }
}

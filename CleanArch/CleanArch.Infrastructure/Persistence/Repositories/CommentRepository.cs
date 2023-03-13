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

        public Task<GetCommentDto> GetCommentByIdAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task SubmitCommentAsync(SubmitCommentDto submitCommentDto)
        {
            throw new NotImplementedException();
        }

        public Task ProcessCommentAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task ApproveCommentAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task RejectCommentAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task PublishCommentAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task BanUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

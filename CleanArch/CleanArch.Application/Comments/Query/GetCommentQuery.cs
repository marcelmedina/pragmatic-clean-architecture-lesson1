using CleanArch.Application.ViewModels;
using CleanArch.Core.Exceptions;
using CleanArch.Core.Repositories;
using MediatR;

namespace CleanArch.Application.Comments.Query
{
    public class GetCommentQuery : IRequest<GetCommentViewModel>
    {
        public GetCommentQuery(int commentId)
        {
            CommentId = commentId;
        }

        public int CommentId { get; set; }
    }

    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, GetCommentViewModel>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetCommentViewModel> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(request.CommentId);

            if (comment == null)
            {
                throw new CommentNotFoundException(request.CommentId);
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
    }
}
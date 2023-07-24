using CleanArch.Application.ViewModels;
using CleanArch.Core.Exceptions;
using CleanArch.Core.Repositories;
using MediatR;

namespace CleanArch.Application.Queries
{
    public class GetCommentByIdQuery : IRequest<GetCommentViewModel>
    {
        public int CommentId { get; }

        public GetCommentByIdQuery(int commentId)
        {
            CommentId = commentId;
        }
    }

    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentViewModel>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetCommentViewModel> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
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

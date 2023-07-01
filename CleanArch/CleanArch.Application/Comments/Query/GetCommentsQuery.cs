using CleanArch.Application.ViewModels;
using CleanArch.Core.Repositories;
using MediatR;

namespace CleanArch.Application.Comments.Query
{
    public class GetCommentsQuery : IRequest<List<GetCommentViewModel>>
    {
    }

    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<GetCommentViewModel>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentsQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentViewModel>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
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
    }
}
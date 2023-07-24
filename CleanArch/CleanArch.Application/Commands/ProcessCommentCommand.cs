using CleanArch.Application.Queries;
using CleanArch.Core.Repositories;
using CleanArch.Core.Services;
using MediatR;

namespace CleanArch.Application.Commands
{
    public class ProcessCommentCommand : IRequest
    {
        public int CommentId { get; }

        public ProcessCommentCommand(int commentId)
        {
            CommentId = commentId;
        }
    }

    public class ProcessCommentCommandHandler : IRequestHandler<ProcessCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IContentModerationService _contentModerationService;
        private readonly IMediator _mediator;

        public ProcessCommentCommandHandler(
            ICommentRepository commentRepository,
            IContentModerationService contentModerationService,
            IMediator mediator)
        {
            _commentRepository = commentRepository;
            _contentModerationService = contentModerationService;
            _mediator = mediator;
        }

        public async Task Handle(ProcessCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _mediator.Send(new GetCommentByIdQuery(request.CommentId), cancellationToken);

            await _commentRepository.ProcessCommentAsync(request.CommentId);

            var hasProfanity = await _contentModerationService.HasProfanity(comment.Description);

            if (hasProfanity)
            {
                // TODO: Transaction
                await _commentRepository.RejectCommentAsync(request.CommentId);
                await _commentRepository.BanUser(comment.UserId);
            }
            else
            {
                await _commentRepository.ApproveCommentAsync(request.CommentId);
            }
        }
    }
}

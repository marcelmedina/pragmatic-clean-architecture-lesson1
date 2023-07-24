using CleanArch.Application.InputModels;
using MediatR;

namespace CleanArch.Application.Commands
{
    public class SubmitCommentCommand : IRequest
    {
        public SubmitCommentInputModel SubmitCommentInputModel { get; }

        public SubmitCommentCommand(SubmitCommentInputModel submitCommentInputModel)
        {
            SubmitCommentInputModel = submitCommentInputModel;
        }
    }

    public class SubmitCommentCommandHandler : IRequestHandler<SubmitCommentCommand>
    {
        public Task Handle(SubmitCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

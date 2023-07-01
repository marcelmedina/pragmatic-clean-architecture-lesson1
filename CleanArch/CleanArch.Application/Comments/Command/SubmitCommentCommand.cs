using CleanArch.Application.InputModels;
using MediatR;

namespace CleanArch.Application.Comments.Command
{
    public class SubmitCommentCommand : IRequest
    {
        public SubmitCommentCommand(SubmitCommentInputModel submitCommentInputModel)
        {
            SubmitCommentInputModel = submitCommentInputModel;
        }

        public SubmitCommentInputModel SubmitCommentInputModel { get; set; }
    }

    public class SubmitCommentCommandHandler : IRequestHandler<SubmitCommentCommand>
    {
        public Task Handle(SubmitCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
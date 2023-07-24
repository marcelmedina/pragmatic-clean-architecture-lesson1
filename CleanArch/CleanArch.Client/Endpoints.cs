using CleanArch.Application.Commands;
using CleanArch.Application.InputModels;
using CleanArch.Application.Notifications;
using CleanArch.Application.Queries;
using CleanArch.Application.ViewModels;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CleanArch.Client
{
    public class Endpoints
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public Endpoints(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _mediator = mediator;
            _logger = loggerFactory.CreateLogger<Endpoints>();
        }

        [Function(nameof(GetComments))]
        public async Task<List<GetCommentViewModel>> GetComments([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# GetComments HTTP trigger function processed a request.");

            var comments = await _mediator.Send(new GetCommentsQuery());

            return comments;
        }

        [Function(nameof(GetCommentById))]
        public async Task<GetCommentViewModel> GetCommentById([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# GetCommentById HTTP trigger function processed a request.");

            var commentId = req.Url.Query.Split("=")[1];

            var comment = await _mediator.Send(new GetCommentByIdQuery(int.Parse(commentId)));

            return comment;
        }

        [Function(nameof(SubmitComment))]
        public async Task SubmitComment([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# SubmitComment HTTP trigger function processed a request.");

            var submitCommentInputModel = await req.ReadFromJsonAsync<SubmitCommentInputModel>();

            if (submitCommentInputModel is null)
            {
                throw new ArgumentNullException(nameof(submitCommentInputModel));
            }
            
            await _mediator.Send(new SubmitCommentCommand(submitCommentInputModel));
        }

        [Function(nameof(ProcessComment))]
        public async Task ProcessComment([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# ProcessComment HTTP trigger function processed a request.");

            var commentId = await req.ReadFromJsonAsync<int>();

            await _mediator.Send(new ProcessCommentCommand(commentId));

            await _mediator.Publish(new ProcessCommentNotification(commentId));
        }
    }
}

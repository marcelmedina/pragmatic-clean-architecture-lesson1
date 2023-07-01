using CleanArch.Application.Comments.Command;
using CleanArch.Application.Comments.Query;
using CleanArch.Application.InputModels;
using CleanArch.Application.ViewModels;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CleanArch.Client
{
    public class Endpoints
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public Endpoints(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<Endpoints>();
            _mediator = mediator;
        }

        [Function(nameof(GetCommentById))]
        public async Task<GetCommentViewModel> GetCommentById([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# GetCommentById HTTP trigger function processed a request.");

            var commentId = System.Web.HttpUtility.ParseQueryString(req.Url.Query).Get("commentId");
                    
            var comment = await _mediator.Send(new GetCommentQuery(Convert.ToInt32(commentId)));

            return comment;
        }

        [Function(nameof(GetComments))]
        public async Task<List<GetCommentViewModel>> GetComments([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# GetComments HTTP trigger function processed a request.");

            var comments = await _mediator.Send(new GetCommentsQuery());

            return comments;
        }

        [Function(nameof(SubmitComment))]
        public async Task SubmitComment([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# SubmitComment HTTP trigger function processed a request.");

            var submitCommentInputModel = await req.ReadFromJsonAsync<SubmitCommentInputModel>();

            await _mediator.Send(new SubmitCommentCommand(submitCommentInputModel));
        }

        [Function(nameof(ProcessComment))]
        public async Task ProcessComment([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# ProcessComment HTTP trigger function processed a request.");

            var commentId = await req.ReadFromJsonAsync<int>();

            await _mediator.Send(new ProcessCommentCommand(commentId));
        }
    }
}

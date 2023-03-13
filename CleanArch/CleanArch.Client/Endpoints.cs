using CleanArch.Application.Services;
using CleanArch.Application.ViewModels;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CleanArch.Client
{
    public class Endpoints
    {
        private readonly ICommentService _commentService;
        private readonly ILogger _logger;

        public Endpoints(ILoggerFactory loggerFactory, ICommentService commentService)
        {
            _commentService = commentService;
            _logger = loggerFactory.CreateLogger<Endpoints>();
        }

        [Function(nameof(Comments))]
        public async Task<List<GetCommentViewModel>> Comments([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var comments = await _commentService.GetCommentsAsync();

            return comments;
        }
    }
}

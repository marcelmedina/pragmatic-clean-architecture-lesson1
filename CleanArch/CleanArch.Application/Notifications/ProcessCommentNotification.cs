using MediatR;

namespace CleanArch.Application.Notifications
{
    public class ProcessCommentNotification : INotification
    {
        public int CommentId { get; }

        public ProcessCommentNotification(int commentId)
        {
            CommentId = commentId;
        }
    }

    public class ProcessCommentLogNotificationHandler : INotificationHandler<ProcessCommentNotification>
    {
        public Task Handle(ProcessCommentNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    public class ProcessCommentClearCacheNotificationHandler : INotificationHandler<ProcessCommentNotification>
    {
        public Task Handle(ProcessCommentNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

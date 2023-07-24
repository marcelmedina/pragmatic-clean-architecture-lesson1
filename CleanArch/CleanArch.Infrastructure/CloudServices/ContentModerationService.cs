using CleanArch.Core.Services;

namespace CleanArch.Infrastructure.CloudServices
{
    public class ContentModerationService : IContentModerationService
    {
        public Task<bool> HasProfanity(string description)
        {
            return Task.FromResult(false);
        }
    }
}

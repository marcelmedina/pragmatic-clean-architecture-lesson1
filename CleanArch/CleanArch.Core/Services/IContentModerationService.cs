namespace CleanArch.Core.Services
{
    public interface IContentModerationService
    {
        Task<bool> HasProfanity(string description);
    }
}

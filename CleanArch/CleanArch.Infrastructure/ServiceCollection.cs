using CleanArch.Core.Repositories;
using CleanArch.Core.Services;
using CleanArch.Infrastructure.CloudServices;
using CleanArch.Infrastructure.Persistence.Repositories;
using CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddInfraCommentDbContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CommentDbContext>(options => options.UseInMemoryDatabase("CommentDatabase"));
            return serviceCollection;
        }

        public static IServiceCollection AddInfraRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
            return serviceCollection;
        }

        public static IServiceCollection AddInfraServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IContentModerationService, ContentModerationService>();
            return serviceCollection;
        }
    }
}

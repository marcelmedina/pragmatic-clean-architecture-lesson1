using CleanArch.Core.Repositories;
using CleanArch.Core.Services;
using CleanArch.Infrastructure.CloudServices;
using CleanArch.Infrastructure.Persistence;
using CleanArch.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommentDbContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CommentDbContext>(options => options.UseInMemoryDatabase("CommentDatabase"));
            return serviceCollection;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
            return serviceCollection;
        }

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IContentModerationService, ContentModerationService>();
            return serviceCollection;
        }

        public static IServiceCollection AddMediator(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(Application.ViewModels.GetCommentViewModel).Assembly);
            });
            return serviceCollection;
        }
    }
}

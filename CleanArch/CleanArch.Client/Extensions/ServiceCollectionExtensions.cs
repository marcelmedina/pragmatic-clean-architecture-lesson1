using CleanArch.Application;
using CleanArch.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommentDbContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddInfraCommentDbContext();
            return serviceCollection;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddInfraRepositories();
            return serviceCollection;
        }

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddInfraServices();
            serviceCollection.AddApplicationServices();
            return serviceCollection;
        }
    }
}

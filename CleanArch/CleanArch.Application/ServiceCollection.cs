using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceCollection).Assembly);
            });
            return serviceCollection;
        }
    }
}

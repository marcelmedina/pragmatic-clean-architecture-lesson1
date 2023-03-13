using CleanArch.Client.Extensions;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(sc =>
    {
        sc.AddCommentDbContext()
            .AddRepositories()
            .AddServices();
    })
    .Build();

host.Run();

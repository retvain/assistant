using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Retvain.Assistant.Application;
using Retvain.Assistant.Application.Contracts;

namespace Retvain.Assistant.Host;

internal static class Startup
{
    internal static void Run(IHost host, string[]? args)
    {
        using var scope = host.Services.CreateScope();

        var root = scope.ServiceProvider.GetRequiredService<IRoot>();
        root.Execute();
    }

    internal static void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationServices();
    }

    internal static void Configure(IHostBuilder builder)
    {
        builder.ConfigureLogging(logging =>
        {
            logging.AddConsole();
        });
    }
}
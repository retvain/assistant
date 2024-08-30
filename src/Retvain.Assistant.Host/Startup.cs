using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Retvain.Assistant.Application;
using Retvain.Assistant.Application.Commands.Root.Contracts;
using Retvain.Assistant.Host.Services;

namespace Retvain.Assistant.Host;

internal static class Startup
{
    internal static void Run(IHost host, string[]? args)
    {
        using var scope = host.Services.CreateScope();

        var command = ArgumentParserService.Parse(args);

        var mediatr = scope.ServiceProvider.GetRequiredService<IMediator>();
        mediatr.Send(new RootCommand(command));
    }

    internal static void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(typeof(ApplicationServicesExtensions).Assembly);

        services.AddApplicationServices();
    }

    internal static void Configure(IHostBuilder builder)
    {
        builder.ConfigureLogging(logging => { logging.AddConsole(); });
    }
}
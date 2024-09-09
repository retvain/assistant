using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Retvain.Assistant.Application;
using Retvain.Assistant.Application.Commands.Root.Contracts;
using Retvain.Assistant.Host.Services;
using Retvain.Assistant.Repository;

namespace Retvain.Assistant.Host;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(typeof(ApplicationServicesExtensions).Assembly);
        services.AddApplicationServices();
        services.AddRepositoryServices();
    }

    public static void Configure(IHostBuilder builder)
    {
        builder.ConfigureLogging(logging => { logging.AddConsole(); });
    }

    public static async Task Run(IHost host, string[]? args)
    {
        using var scope = host.Services.CreateScope();
        var argument = ArgumentParserService.Parse(args ?? Array.Empty<string>());
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        
        await mediator.Send(new RootCommand(argument));
    }
}
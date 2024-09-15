using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Retvain.Assistant.Application;
using Retvain.Assistant.Host.Services;
using Retvain.Assistant.Infrastructure;
using Retvain.Assistant.Repository;

namespace Retvain.Assistant.Host;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(typeof(ApplicationServicesExtensions).Assembly);
        services.AddApplicationServices();
        services.AddRepositoryServices();
        services.AddInfrastructureServices();
    }

    public static void Configure(IHostBuilder builder)
    {
        builder.ConfigureLogging(logging => { logging.AddConsole(); });
    }

    public static async Task Run(IHost host, string[]? args)
    {
        using var scope = host.Services.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        var commandName = ArgumentParser.GetCommandName(args);
        var options = ArgumentParser.GetCommandOptions(args);

        var command = CommandResolver.Resolve(commandName, options);

        var result = await mediator.Send(command);

        Console.WriteLine(result.Get());
    }
}
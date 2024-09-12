using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Retvain.Assistant.Application.Commands.Root;
using Retvain.Assistant.Application.Commands.Root.Contracts;
using Retvain.Assistant.Application.Commands.Root.Services;

namespace Retvain.Assistant.Application;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<CommandResolver>();

        AddMediatr(services);
    }

    private static void AddMediatr(IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<RootCommand>, RootCommandHandler>();
    }
}
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Retvain.Assistant.Application.Commands.Root;
using Retvain.Assistant.Application.Commands.Root.Contracts;

namespace Retvain.Assistant.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        AddMediatr(services);

        return services;
    }

    private static void AddMediatr(IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<RootCommand>, RootCommandHandler>();
    }
}
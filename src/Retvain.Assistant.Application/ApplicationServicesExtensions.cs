using Microsoft.Extensions.DependencyInjection;
using Retvain.Assistant.Application.Contracts;

namespace Retvain.Assistant.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRoot, Root>();

        return services;
    }
}
using Microsoft.Extensions.DependencyInjection;
using Retvain.Assistant.Application.Ports;
using Retvain.Assistant.Repository.InMemory;

namespace Retvain.Assistant.Repository;

public static class RepositoryServicesExtensions
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddSingleton<ICommandStore, CommandStore>();
    }
}
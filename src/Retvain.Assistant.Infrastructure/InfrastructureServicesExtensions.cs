using Microsoft.Extensions.DependencyInjection;
using Retvain.Assistant.Application.Commands.PureS.Ports;
using Retvain.Assistant.Infrastructure.PureServers;

namespace Retvain.Assistant.Infrastructure;

public static class InfrastructureServicesExtensions
{
    public static void AddInfrastructureServices(
        this IServiceCollection services,
        PureServersConfiguration pureServersConfiguration)
    {
        services.AddSingleton<IPureServersClient>(s => new PureServersApiClient(pureServersConfiguration));
    }
}
using Retvain.Assistant.Application.Commands.PureS.Ports;

namespace Retvain.Assistant.Application.Commands.PureS.Services;

internal sealed class PureServersService(IPureServersClient pureServersClient)
{
    public async Task<IReadOnlyCollection<string>> GetServersList()
    {
        var serversList = await pureServersClient.GetServersList(CancellationToken.None);

        var servers = new List<string>(serversList.Count);
        servers.AddRange(serversList.Select(server => server.ToString()));

        return servers;
    }
}
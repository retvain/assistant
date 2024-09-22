using Retvain.Assistant.Application.Commands.PureS.Ports;

namespace Retvain.Assistant.Application.Commands.PureS.Services;

internal sealed class PureServersService(IPureServersClient pureServersClient)
{
    public async Task<IReadOnlyCollection<string>> GetServersList()
    {
        var session = await pureServersClient.StartNewSession();
        
        var servers = new List<string>();

        servers.Add("server1");

        return await Task.FromResult<IReadOnlyCollection<string>>(servers);
    }
}
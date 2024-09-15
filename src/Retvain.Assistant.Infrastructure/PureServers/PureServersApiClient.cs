using Retvain.Assistant.Application.Commands.PureS.Ports;

namespace Retvain.Assistant.Infrastructure.PureServers;

public sealed class PureServersApiClient : IPureServersClient
{
    public Task<string> Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }
}
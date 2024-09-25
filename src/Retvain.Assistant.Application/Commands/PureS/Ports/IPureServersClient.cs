using Retvain.Assistant.Application.Commands.PureS.Contracts.Dto.Response;

namespace Retvain.Assistant.Application.Commands.PureS.Ports;

public interface IPureServersClient
{
    public Task<IReadOnlyCollection<Server>> GetServersList(CancellationToken cancellationToken);
}
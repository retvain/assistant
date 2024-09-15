using MediatR;
using Retvain.Assistant.Application.Commands.Help.Contracts;
using Retvain.Assistant.Application.Ports;

namespace Retvain.Assistant.Application.Commands.Help;

internal sealed class HelpCommandHandler(ICommandStore commandStore) : IRequestHandler<HelpCommand, ICommandResult>
{
    public Task<ICommandResult> Handle(HelpCommand request, CancellationToken cancellationToken)
    {
        var availableCommandList = commandStore.GetAll();

        var result = $"list of available commands: {string.Join(
            ", ",
            availableCommandList.Select(x => x.Name.ToString().ToLower()))}.";

        return Task.FromResult<ICommandResult>(new HelpResult(result));
    }
}
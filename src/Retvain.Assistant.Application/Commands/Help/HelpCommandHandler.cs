using System.Windows.Input;
using MediatR;
using Retvain.Assistant.Application.Commands.Help.Contracts;
using Retvain.Assistant.Application.Ports;

namespace Retvain.Assistant.Application.Commands.Help;

internal sealed class HelpCommandHandler(ICommandStore commandStore) : IRequestHandler<HelpCommand>
{
    public async Task<Unit> Handle(HelpCommand request, CancellationToken cancellationToken)
    {
        var availableCommandList = commandStore.GetAll();

        Console.WriteLine($"list of available commands: {string.Join(
                ", ",
                availableCommandList.Select(x => x.Name.ToString().ToLower()))}."
            );

        return await Task.FromResult(Unit.Value);
    }
}
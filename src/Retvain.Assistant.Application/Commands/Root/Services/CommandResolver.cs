using MediatR;
using Retvain.Assistant.Application.Commands.Help.Contracts;
using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Application.Commands.Root.Services;

internal sealed class CommandResolver
{
    private readonly IReadOnlyDictionary<CommandName, IRequest> _availableCommands =
        new Dictionary<CommandName, IRequest>
        {
            { CommandName.Help, new HelpCommand() }
        };

    public IRequest Get(CommandName? commandName)
    {
        if (commandName.HasValue && _availableCommands.TryGetValue(commandName.Value, out var command))
            return command;

        return _availableCommands[CommandName.Help];
    }
}
using MediatR;
using Retvain.Assistant.Application.Commands;
using Retvain.Assistant.Application.Commands.Help.Contracts;
using Retvain.Assistant.Application.Commands.PureS.Contracts;
using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Host.Services;

internal static class CommandResolver
{
    public static IRequest<ICommandResult> Resolve(string commandName, IDictionary<string, string?>? options)
    {
        var commandIsFounded = Enum.TryParse<CommandName>(commandName, true, out var name);

        return commandIsFounded ? GetCommandByName(name, options) : GetCommandByName(CommandName.Help);
    }

    private static IRequest<ICommandResult> GetCommandByName(CommandName commandName,
        IDictionary<string, string?>? parsedOptions = null)
    {
        var commandOptions = ToCommandOptions(parsedOptions);

        var availableCommands = new Dictionary<CommandName, IRequest<ICommandResult>>
        {
            [CommandName.Help] = new HelpCommand(commandOptions),
            [CommandName.PureS] = new PureSCommand(commandOptions)
        };

        if (availableCommands.TryGetValue(commandName, out var command))
            return command;

        throw new ArgumentException($"Can't resolve {commandName}");
    }

    private static IReadOnlyCollection<CommandOption>? ToCommandOptions(IDictionary<string, string?>? parsedOptions)
    {
        List<CommandOption>? options = null;

        if (parsedOptions is null)
            return options;

        options = new List<CommandOption>(parsedOptions.Count);
        options.AddRange(parsedOptions.Select(option => new CommandOption(option.Key, option.Value)));

        return options.ToArray();
    }
}
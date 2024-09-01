using Retvain.Assistant.Application.Ports;
using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Repository.InMemory;

internal sealed class CommandStore : ICommandStore
{
    private readonly IReadOnlyDictionary<CommandName, Command> _commands =
        new Dictionary<CommandName, Command>
        {
            { CommandName.Help, new Command(CommandName.Help) }
        };

    public IReadOnlyCollection<Command> GetAll()
    {
        return _commands.Values.ToArray(); 
    }

    public Command? Get(CommandName commandName)
    {
        if (_commands.TryGetValue(commandName, out var command))
            return command;
        
        return null;
    }
}
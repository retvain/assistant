using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Application.Ports;

public interface ICommandStore
{
    IReadOnlyCollection<Command> GetAll();

    Command? Get(CommandName commandName);
}
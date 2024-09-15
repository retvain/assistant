using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Application.Commands;

public abstract class BaseCommand(IReadOnlyCollection<CommandOption>? options = null)
{
    public IReadOnlyCollection<CommandOption>? Options { get; } = options;

    public bool OptionsIsEmpty()
    {
        return Options is null || Options.Count < 1;
    }
}
using Retvain.Assistant.Domain.Command;
using Retvain.Assistant.Domain.Primitives;

namespace Retvain.Assistant.Host.Services;

internal static class ArgumentParserService
{
    public static Command Parse(string[]? args)
    {
        var command = string.Empty;

        if (args is not null && args.Length > 0)
        {
            command = args[0];
        }

        var commandName = new CommandName(command);

        return new Command(commandName);
    }
}
using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Host.Services;

internal static class ArgumentParserService
{
    public static CommandName? Parse(string[]? args)
    {
        return CommandName.Help;
    }
}
namespace Retvain.Assistant.Application.Commands.Help.Contracts;

internal sealed class HelpResult(string result) : ICommandResult
{
    public string Get()
    {
        return result;
    }

    public static HelpResult Empty()
    {
        return new HelpResult(string.Empty);
    }
}
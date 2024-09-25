namespace Retvain.Assistant.Application.Commands.PureS.Contracts;

internal sealed class PureSResult(string result) : ICommandResult
{
    public string Get()
    {
        return result;
    }
}
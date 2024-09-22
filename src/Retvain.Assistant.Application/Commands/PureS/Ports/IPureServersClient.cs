namespace Retvain.Assistant.Application.Commands.PureS.Ports;

public interface IPureServersClient
{
    public Task<string> StartNewSession();
}
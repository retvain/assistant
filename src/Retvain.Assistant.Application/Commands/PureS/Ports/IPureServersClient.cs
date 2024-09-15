namespace Retvain.Assistant.Application.Commands.PureS.Ports;

public interface IPureServersClient
{
    public Task<string> Authenticate(string username, string password);
}
namespace Retvain.Assistant.Infrastructure.Ports;

public interface ICacheManager
{
    string? GetPureServersSession();

    void SetPureServersSession(string session);
}
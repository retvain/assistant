using System.Text.Json;
using Retvain.Assistant.Application.Commands.PureS.Ports;
using Retvain.Assistant.Infrastructure.Ports;
using Retvain.Assistant.Infrastructure.PureServers.Converters.Response;
using Retvain.Assistant.Infrastructure.PureServers.Dto.Response;
using Retvain.Assistant.Infrastructure.Utils;

namespace Retvain.Assistant.Infrastructure.PureServers;

using Application = Application.Commands.PureS.Contracts.Dto.Response;

internal sealed class PureServersApiClient(
    PureServersConfiguration configuration,
    ICacheManager cacheManager) : IPureServersClient
{
    private const string SessionHeaderKey = "session";
    private readonly HttpClient _httpClient = new();

    public async Task<IReadOnlyCollection<Application.Server>> GetServersList(CancellationToken cancellationToken = default)
    {
        var sessionHeaderValue = await StartSession();
        _httpClient.DefaultRequestHeaders.Add(SessionHeaderKey, sessionHeaderValue);

        var response = await _httpClient.GetAsync(configuration.Hosts.Servers.List, cancellationToken);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        var servers = JsonSerializer.Deserialize<List<Server>>(responseContent);

        if (servers is null)
            return Array.Empty<Application.Server>();

        return ServerConvertor.ToApplication(servers);
    }

    private async Task<string> StartSession()
    {
        const string logged = "LoggedIn";

        var currentSession = cacheManager.GetPureServersSession();

        if (currentSession is not null && currentSession != string.Empty)
            return currentSession;

        Console.Write("Need authentication. \n");
        Console.Write("Enter email: ");
        var email = Console.ReadLine();

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        var httpContent = Request.ToHttpContent(new { email, password });

        var response = await _httpClient.PostAsync(configuration.Hosts.Authorization, httpContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        if (!responseContent.Contains(logged))
            throw new HttpRequestException($"Failed to authenticate: {responseContent}");

        if (!response.Headers.TryGetValues(SessionHeaderKey, out var session))
            throw new HttpRequestException($"Failed to get session: {responseContent}");

        var newSession = session.First();
        cacheManager.SetPureServersSession(newSession);

        return newSession;
    }
}
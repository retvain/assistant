using Retvain.Assistant.Application.Commands.PureS.Ports;
using Retvain.Assistant.Infrastructure.Utils;

namespace Retvain.Assistant.Infrastructure.PureServers;

public sealed class PureServersApiClient(PureServersConfiguration configuration) : IPureServersClient
{
    private readonly HttpClient _httpClient = new();

    public async Task<string> StartNewSession()
    {
        // todo save session in settings, enter email and user inline
        const string logged = "LoggedIn";
        const string sessionHeaderName = "session";
        
        Console.Write("Enter email: ");
        var email = Console.ReadLine();
        
        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        var content = Request.ToContent(
            new
            {
                email,
                password
            });

        var response = await _httpClient.PostAsync(configuration.Hosts.Authorization, content);
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"Failed to authenticate: {response.ReasonPhrase}");
        
        var responseContent = await response.Content.ReadAsStringAsync();
        if (!responseContent.Contains(logged))
            throw new HttpRequestException($"Failed to authenticate: {responseContent}");
        
        if (response.Headers.TryGetValues(sessionHeaderName, out var session))
            return session.First();
        
        throw new HttpRequestException($"Failed to get session: {responseContent}");
    }
}
using AutoFixture;
using Microsoft.AspNetCore.TestHost;
using Retvain.Assistant.Host;
using Retvain.Assistant.IntegrationTests.Tools;

namespace Retvain.Assistant.IntegrationTests;

public abstract class BaseTest
{
    protected IFixture Fixture { get; } = new Fixture();

    protected async Task<string> RunApp(string[] args)
    {
        await using HostApplicationFactory<Startup> hostApplicationFactory =
            new(configuration: builder =>
            {
                builder.UseSetting("SomeAppSetting:Key", "replacement value");

                builder.ConfigureTestServices(services => { });
            });

        return await hostApplicationFactory.RunHostAsync(args);
    }

    protected string CleanUp(string source)
    {
        var result = source
            .Replace("\r", string.Empty)
            .Replace("\n", string.Empty);

        return result;
    }
}
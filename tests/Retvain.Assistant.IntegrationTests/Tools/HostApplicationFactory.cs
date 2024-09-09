using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Retvain.Assistant.Host;

namespace Retvain.Assistant.IntegrationTests.Tools;

public sealed class HostApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint>
    where TEntryPoint : class
{
    private readonly Action<IWebHostBuilder> _configuration;

    public HostApplicationFactory(Action<IWebHostBuilder> configuration)
    {
        _configuration = configuration;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder) =>
        _configuration(builder.Configure(_ => { }));

    public async Task<string> RunHostAsync(string[] args)
    {
        var host = Services.GetRequiredService<IHost>();

        var output = new StringWriter();
        Console.SetOut(output);

        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Testing");

        // Запуск асинхронного метода Run
        await Startup.Run(host, args);

        return output.ToString();
    }

}
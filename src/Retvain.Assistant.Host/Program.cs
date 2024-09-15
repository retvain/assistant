using Microsoft.Extensions.Hosting;

namespace Retvain.Assistant.Host;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHost(args);

        await Startup.Run(host, args);
    }

    private static IHost CreateHost(string[] args)
    {
        var builder = CreateHostBuilder(args);
        Startup.Configure(builder);
        return builder.Build();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                Startup.ConfigureServices(services);
            });
}
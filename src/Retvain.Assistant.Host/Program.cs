using Microsoft.Extensions.Hosting;
using Retvain.Assistant.Host;

public class Program
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
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                Startup.ConfigureServices(services);
            });
}
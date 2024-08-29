using Microsoft.Extensions.Hosting;
using Retvain.Assistant.Host;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    Startup.ConfigureServices(services);
});

Startup.Configure(builder);

var host = builder.Build();

Startup.Run(host, args);
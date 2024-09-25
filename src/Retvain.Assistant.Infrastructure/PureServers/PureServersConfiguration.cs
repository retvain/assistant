namespace Retvain.Assistant.Infrastructure.PureServers;

public sealed class PureServersConfiguration
{
    public HostsConfiguration Hosts { get; init; } = new();

    public sealed class HostsConfiguration
    {
        public string Authorization { get; set; } = string.Empty;

        public ServersConfiguration Servers { get; init; } = new();

        public sealed class ServersConfiguration
        {
            public string List { get; set; } = string.Empty;
        }
    }
}
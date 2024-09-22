namespace Retvain.Assistant.Infrastructure.PureServers;

public sealed class PureServersConfiguration
{
    public HostsConfiguration Hosts { get; set; } = new HostsConfiguration();

    public sealed class HostsConfiguration
    {
        public string Authorization { get; set; } = string.Empty;
    }
}
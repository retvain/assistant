using System.Text.Json.Serialization;

namespace Retvain.Assistant.Infrastructure.PureServers.Dto.Response;

internal sealed class Server
{
    [JsonPropertyName("_id")]
    public required string Id { get; set; }

    [JsonPropertyName("os")]
    public required string Os { get; set; }

    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [JsonPropertyName("password")]
    public required string Password { get; set; }

    [JsonPropertyName("tariff_id")]
    public required string TariffId { get; set; }

    [JsonPropertyName("expires_at")]
    public long ExpiresAt { get; set; }

    [JsonPropertyName("tuntap_enabled")]
    public bool TuntapEnabled { get; set; }

    [JsonPropertyName("nesting_enabled")]
    public bool NestingEnabled { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("num_id")]
    public int NumId { get; set; }

    [JsonPropertyName("linked_ips")]
    public required List<LinkedIp> LinkedIps { get; set; }

    [JsonPropertyName("tariff_name")]
    public required string TariffName { get; set; }

    [JsonPropertyName("state")]
    public required ServerState State { get; set; }

    internal sealed class LinkedIp
    {
        [JsonPropertyName("_id")]
        public required string Id { get; set; }

        [JsonPropertyName("ip")]
        public required string Ip { get; set; }
    }

    internal sealed class ServerState
    {
        [JsonPropertyName("cpu")]
        public double Cpu { get; set; }

        [JsonPropertyName("max_cpu")]
        public double MaxCpu { get; set; }

        [JsonPropertyName("ram")]
        public double Ram { get; set; }

        [JsonPropertyName("max_ram")]
        public double MaxRam { get; set; }

        [JsonPropertyName("disk")]
        public double Disk { get; set; }

        [JsonPropertyName("max_disk")]
        public double MaxDisk { get; set; }

        [JsonPropertyName("status")]
        public required string Status { get; set; }
    }
}
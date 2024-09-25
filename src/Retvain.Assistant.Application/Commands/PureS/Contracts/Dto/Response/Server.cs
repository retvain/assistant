namespace Retvain.Assistant.Application.Commands.PureS.Contracts.Dto.Response;

public sealed class Server
{
    public required string Id { get; init; }

    public required string Os { get; init; }

    public required string Username { get; init; }

    public required string Password { get; init; }

    public DateOnly ExpiresAt { get; init; }

    public required string Status { get; init; }

    public int NumId { get; init; }

    public required List<LinkedIp> LinkedIps { get; init; }

    public required string TariffName { get; init; }

    public required ServerState State { get; init; }

    public sealed class LinkedIp
    {
        public required string Id { get; init; }

        public required string Ip { get; init; }
    }

    public sealed class ServerState
    {
        public double Cpu { get; init; }

        public double MaxCpu { get; init; }

        public double Ram { get; init; }

        public double MaxRam { get; init; }

        public double Disk { get; init; }

        public double MaxDisk { get; init; }

        public required string Status { get; init; }
    }

    public override string ToString()
    {
        var linkedIps = string.Join(", ", LinkedIps.Select(ip => $"{ip.Id}: {ip.Ip}"));
        return $"Server Details:\n" +
               $"Status: {Status}\n" +
               $"State:\n" +
               $"  CPU: {Math.Round(State.Cpu * 100, 2)}% / {Math.Round(State.MaxCpu * 100, 2)}%\n" +
               $"  RAM: {FormatSize(State.Ram, State.MaxRam)} / {State.MaxRam} GB\n" +
               $"  Disk: {FormatSize(State.Disk, State.MaxDisk)} / {State.MaxDisk} GB\n" +
               $"  Status: {State.Status}\n\n" +
               $"ID: {Id}\n" +
               $"OS: {Os}\n" +
               $"Username: {Username}\n" +
               $"Password: {Password}\n" +
               $"Expires At: {ExpiresAt}\n" +
               $"Num ID: {NumId}\n" +
               $"Linked IPs: {linkedIps}\n" +
               $"Tariff Name: {TariffName}";
    }

    private static string FormatSize(double size, double maxSize)
    {
        var usedSize = size * maxSize;

        if (usedSize < 1)
            return $"{Math.Round(usedSize * 1024, 2)} MB";

        return $"{Math.Round(usedSize, 2)} GB";
    }
}
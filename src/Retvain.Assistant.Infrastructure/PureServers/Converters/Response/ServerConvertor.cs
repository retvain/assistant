using Server = Retvain.Assistant.Infrastructure.PureServers.Dto.Response.Server;

namespace Retvain.Assistant.Infrastructure.PureServers.Converters.Response;

using Application = Application.Commands.PureS.Contracts.Dto.Response;

internal static class ServerConvertor
{
    public static IReadOnlyCollection<Application.Server> ToApplication(IReadOnlyCollection<Server> servers)
    {
        return servers.Select(server => new Application.Server
        {
            Id = server.Id,
            Os = server.Os,
            Username = server.Username,
            Password = server.Password,
            ExpiresAt = ToDateOnly(server.ExpiresAt),
            Status = server.Status,
            NumId = server.NumId,
            LinkedIps = server.LinkedIps.Select(ip => new Application.Server.LinkedIp
            {
                Id = ip.Id,
                Ip = ip.Ip
            }).ToList(),
            TariffName = server.TariffName,
            State = new Application.Server.ServerState
            {
                Cpu = server.State.Cpu,
                MaxCpu = server.State.MaxCpu,
                Ram = server.State.Ram,
                MaxRam = server.State.MaxRam,
                Disk = server.State.Disk,
                MaxDisk = server.State.MaxDisk,
                Status = server.State.Status
            }
        }).ToList();
    }

    private static DateOnly ToDateOnly(long unixTimeMilliseconds)
    {
        var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds).DateTime;

        return DateOnly.FromDateTime(dateTime);
    }
}
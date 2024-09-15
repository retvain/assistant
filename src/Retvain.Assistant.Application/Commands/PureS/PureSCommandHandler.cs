using MediatR;
using Retvain.Assistant.Application.Commands.PureS.Contracts;
using Retvain.Assistant.Application.Commands.PureS.Services;

namespace Retvain.Assistant.Application.Commands.PureS;

internal sealed class PureSCommandHandler(PureServersService pureServersService) : IRequestHandler<PureSCommand, ICommandResult>
{
    private const string ListOption = "list";

    public async Task<ICommandResult> Handle(PureSCommand command, CancellationToken cancellationToken)
    {
        if (command.OptionsIsEmpty())
            return await ResultWith("options required");

        foreach (var option in command.Options!)
        {
            switch (option.Name)
            {
                case ListOption: return await ResultWith(await GetList());
            }
        }

        return await ResultWith(string.Empty);
    }

    private async Task<string> GetList()
    {
        var servers = await pureServersService.GetServersList();

        return string.Join(", ", servers);
    }

    private static async Task<ICommandResult> ResultWith(string result)
    {
        return await Task.FromResult<ICommandResult>(new PureSResult(result));
    }
}
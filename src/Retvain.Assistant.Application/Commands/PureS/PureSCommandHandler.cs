using MediatR;
using Retvain.Assistant.Application.Commands.PureS.Contracts;

namespace Retvain.Assistant.Application.Commands.PureS;

internal sealed class PureSCommandHandler : IRequestHandler<PureSCommand, ICommandResult>
{
    private const string StatusOption = "status";

    public async Task<ICommandResult> Handle(PureSCommand command, CancellationToken cancellationToken)
    {
        if (command.OptionsIsEmpty())
            return await Task.FromResult<ICommandResult>(new PureSResult("options required"));

        foreach (var option in command.Options!)
        {
            switch (option.Name)
            {
                case StatusOption: return await Task.FromResult(GetStatus());
            }
        }

        return await Task.FromResult<ICommandResult>(PureSResult.Empty());
    }

    private ICommandResult GetStatus()
    {
        return new PureSResult("status is checked");
    }
}
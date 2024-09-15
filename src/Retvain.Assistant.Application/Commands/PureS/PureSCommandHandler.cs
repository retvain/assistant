using MediatR;
using Retvain.Assistant.Application.Commands.Help.Contracts;
using Retvain.Assistant.Application.Commands.PureS.Contracts;

namespace Retvain.Assistant.Application.Commands.PureS;

internal sealed class PureSCommandHandler(IMediator mediator) : IRequestHandler<PureSCommand, ICommandResult>
{
    public async Task<ICommandResult> Handle(PureSCommand request, CancellationToken cancellationToken)
    {
        var options = request.Options;

        var result = string.Empty;
        var output = await mediator.Send(new HelpCommand(), cancellationToken);


        return PureSResult.Empty();
    }
}
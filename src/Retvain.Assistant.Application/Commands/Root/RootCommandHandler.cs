using MediatR;
using Retvain.Assistant.Application.Commands.Root.Contracts;
using Retvain.Assistant.Application.Commands.Root.Services;

namespace Retvain.Assistant.Application.Commands.Root;

internal sealed class RootCommandHandler(CommandResolver commandResolver, IMediator mediator)
    : IRequestHandler<RootCommand>
{
    public async Task<Unit> Handle(RootCommand request, CancellationToken cancellationToken)
    {
        var command = commandResolver.Get(request.CommandName);

        await mediator.Send(command, cancellationToken);

        return await Task.FromResult(Unit.Value);
    }
}
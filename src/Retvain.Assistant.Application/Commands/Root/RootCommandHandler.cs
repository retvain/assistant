using MediatR;
using Retvain.Assistant.Application.Commands.Root.Contracts;

namespace Retvain.Assistant.Application.Commands.Root;

internal sealed class RootCommandHandler : IRequestHandler<RootCommand>
{
    public async Task<Unit> Handle(RootCommand request, CancellationToken cancellationToken)
    {
        var command = request.Command;

        Console.WriteLine($"Command {command.Name.Value} is running");

        return await Task.FromResult(Unit.Value);
    }
}
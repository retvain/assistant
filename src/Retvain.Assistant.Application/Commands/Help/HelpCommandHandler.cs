using MediatR;
using Retvain.Assistant.Application.Commands.Help.Contracts;

namespace Retvain.Assistant.Application.Commands.Help;

internal sealed class HelpCommandHandler : IRequestHandler<HelpCommand>
{
    public async Task<Unit> Handle(HelpCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("sorry, i can't help you yet.");
        
        return await Task.FromResult(Unit.Value);
    }
}
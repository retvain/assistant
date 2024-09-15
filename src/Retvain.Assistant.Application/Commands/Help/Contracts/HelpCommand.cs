using MediatR;
using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Application.Commands.Help.Contracts;

public sealed class HelpCommand(IReadOnlyCollection<CommandOption>? options = null)
    : IRequest<HelpResult>
{
    public IReadOnlyCollection<CommandOption>? Options { get; } = options;
}
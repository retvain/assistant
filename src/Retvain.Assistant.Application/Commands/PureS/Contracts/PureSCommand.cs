using MediatR;
using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Application.Commands.PureS.Contracts;

public sealed class PureSCommand(IReadOnlyCollection<CommandOption>? options)
    : IRequest<PureSResult>
{
    public IReadOnlyCollection<CommandOption>? Options { get; } = options;
}
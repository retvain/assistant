using MediatR;
using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Application.Commands.PureS.Contracts;

public sealed class PureSCommand(IReadOnlyCollection<CommandOption>? options)
    : BaseCommand(options), IRequest<PureSResult>
{

}
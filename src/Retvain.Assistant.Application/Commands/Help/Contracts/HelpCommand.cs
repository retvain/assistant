using MediatR;
using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Application.Commands.Help.Contracts;

public sealed class HelpCommand(IReadOnlyCollection<CommandOption>? options = null)
    : BaseCommand(options), IRequest<HelpResult>
{

}
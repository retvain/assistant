using MediatR;
using Retvain.Assistant.Domain;

namespace Retvain.Assistant.Application.Commands.Root.Contracts;

public sealed class RootCommand(CommandName? commandName) : IRequest
{
    public CommandName? CommandName { get; } = commandName;
}
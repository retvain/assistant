using MediatR;
using Retvain.Assistant.Domain.Command;

namespace Retvain.Assistant.Application.Commands.Root.Contracts;

public sealed class RootCommand(Command command) : IRequest
{
    public Command Command { get; } = command;
}
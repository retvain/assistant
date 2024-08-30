using Retvain.Assistant.Domain.Primitives;

namespace Retvain.Assistant.Domain.Command;

public readonly record struct Command(CommandName Name);
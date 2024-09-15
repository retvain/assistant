namespace Retvain.Assistant.Domain;

public readonly record struct CommandOption(
    string Name,
    string? Value);
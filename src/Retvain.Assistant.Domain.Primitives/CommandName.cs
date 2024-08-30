using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Retvain.Assistant.Domain.Primitives;

[DebuggerDisplay("{Value}")]
[StructLayout(LayoutKind.Auto)]
public readonly struct CommandName(string name) : IComparable<CommandName>, IEquatable<CommandName>
{
    public static readonly CommandName Empty = new(string.Empty);

    public string Value { get; } = name;

    public int CompareTo(CommandName other)
    {
        return string.Compare(Value, other.Value, StringComparison.Ordinal);
    }

    public bool Equals(CommandName other)
    {
        return Value == other.Value;
    }
}
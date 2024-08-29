using Retvain.Assistant.Application.Contracts;

namespace Retvain.Assistant.Application;

internal sealed class Root : IRoot
{
    public void Execute()
    {
        Console.WriteLine($"Root: test");
    }
}
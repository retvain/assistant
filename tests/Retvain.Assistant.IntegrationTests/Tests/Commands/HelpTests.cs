using AutoFixture;
using NUnit.Framework;

namespace Retvain.Assistant.IntegrationTests.Tests.Commands;

public sealed class HelpTests : BaseTest
{
    private IFixture Fixture { get; } = new Fixture();

    [Test]
    public async Task TestConsoleAppOutput()
    {
        var output = await RunApp(["help"]);
    }
}
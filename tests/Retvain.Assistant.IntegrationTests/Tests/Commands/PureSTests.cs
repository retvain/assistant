using FluentAssertions;
using NUnit.Framework;

namespace Retvain.Assistant.IntegrationTests.Tests.Commands;

public sealed class PureSTests : BaseTest
{
    [Test]
    public async Task HasNoOptions()
    {
        var output = await RunApp(["pures"]);
        CleanUp(output).Should().Be("options required");
    }

    [Test]
    public async Task StatusOption()
    {
        var output = await RunApp(["pures", "status"]);
        CleanUp(output).Should().Be("status is checked");
    }
}
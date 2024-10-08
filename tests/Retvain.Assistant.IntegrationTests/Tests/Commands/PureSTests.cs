﻿using FluentAssertions;
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
    [Ignore("in progress")]
    public async Task ListOption()
    {
        var output = await RunApp(["pures", "list"]);
        CleanUp(output).Should().Be("server1");
    }
}
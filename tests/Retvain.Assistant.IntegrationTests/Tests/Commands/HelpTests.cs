﻿using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace Retvain.Assistant.IntegrationTests.Tests.Commands;

public sealed class HelpTests : BaseTest
{
    [Test]
    public async Task HelpConsoleAppOutput()
    {
        var output = await RunApp(["help"]);

        CleanUp(output).Should().Be("list of available commands: help, pures.");
    }
}
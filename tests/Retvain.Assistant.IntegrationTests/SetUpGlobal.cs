using NUnit.Framework;

namespace Retvain.Assistant.IntegrationTests;

[SetUpFixture]
public sealed class SetUpGlobal
{
    [OneTimeSetUp]
    public void TestSetUp()
    {
        if (Environment.GetEnvironmentVariable("CI") != "true")
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Testing");

        Console.WriteLine("Setting up the test environment...");
    }

    [OneTimeTearDown]
    public void TestTearDown()
    {
        Console.WriteLine("Tearing down the test environment...");
    }
}
namespace Retvain.Assistant.Host.Services;

internal static class ArgumentParser
{
    public static string GetCommandName(string[]? args)
    {
        if (args == null || args.Length < 1)
            return string.Empty;

        return args.First();
    }

    public static IDictionary<string, string?>? GetCommandOptions(string[]? args)
    {
        var options = new Dictionary<string, string?>();

        if (args == null || args.Length < 1)
            return null;

        for (var i = 1; i < args.Length; i += 2)
            options[args[i]] = args[i + 1];

        return options;
    }
}
using System.Text;
using System.Text.Json;

namespace Retvain.Assistant.Infrastructure.Utils;

internal static class Request
{
    public static StringContent ToHttpContent(object value)
        => new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
}
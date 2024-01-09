using System.Text.Json;
using System.Text.Json.Serialization;

namespace MVC.Project.Extensions;

public static class CustomExtensions
{
    public static string ToJson<T>(this T value, bool camelCase = false)
    {
        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        if (camelCase)
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        return JsonSerializer.Serialize(value, options);
    }

    public static T DeserializeJson<T>(this string json, bool camelCase = false, bool insensitivePropertyName = false)
    {
        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = insensitivePropertyName
        };
        if (camelCase)
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        return JsonSerializer.Deserialize<T>(json, options);
    }
}
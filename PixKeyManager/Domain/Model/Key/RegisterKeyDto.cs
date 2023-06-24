using System.Text.Json.Serialization;

namespace PixKeyManager.Domain.Model.Key;

public class RegisterKeyDto
{
    public string? Value { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required KeyType Type { get; set; }
}


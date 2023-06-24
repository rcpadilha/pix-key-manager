using System.Text.Json.Serialization;

namespace PixKeyManager.Domain.Model.Key;

public class RegisterKeyResultDto
{
    public string Value { get; }

    public DateTime CreatedAt { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public KeyType Type { get; }

    public RegisterKeyResultDto(string value, KeyType type, DateTime createdAt)
    {
        Value = value;
        Type = type;
        CreatedAt = createdAt;
    }
}


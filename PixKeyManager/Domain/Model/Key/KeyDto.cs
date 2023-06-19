using System;
using System.Text.Json.Serialization;
using PixKeyManager.Data.Model;

namespace PixKeyManager.Domain.Model.Key;

public class KeyDto
{
    public KeyDto(string id, string value, KeyType type)
    {
        Id = id;
        Value = value;
        Type = type;
    }

    public string Id { get; }
    public string Value { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public KeyType Type { get; }
}



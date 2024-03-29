﻿using System.Text.Json.Serialization;

namespace PixKeyManager.Domain.Model.Key;

public class KeyDto
{
    public string Id { get; }
    public string Value { get; }

    public DateTime CreatedAt { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public KeyType Type { get; }

    public KeyDto(string id, string value, KeyType type, DateTime createdAt)
    {
        Id = id;
        Value = value;
        Type = type;
        CreatedAt = createdAt;
    }
}



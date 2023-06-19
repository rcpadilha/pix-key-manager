using System;
using System.Text.Json.Serialization;
using PixKeyManager.Data.Model;

namespace PixKeyManager.Domain.Model.Key;

public class RegisterKeyDto
{

    public required string Value { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required KeyType Type { get; set; }

    public required string AccountId { get; set; }

}


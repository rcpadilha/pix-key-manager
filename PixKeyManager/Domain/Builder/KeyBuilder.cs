using System;
using PixKeyManager.Data.Model;
using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.Domain.Builder;

public class KeyBuilder: IKeyBuilder
{
    public Key build(RegisterKeyDto dto)
    {
        return new Key
        {
            Value = dto.Value,
            Type = dto.Type.ToString(),
            AccountId = dto.AccountId,
        };
    }

    public KeyDto build(Key entity)
    {
        return new KeyDto
        (
            entity.Id ?? "",
            entity.Value,
            (KeyType) Enum.Parse(typeof(KeyType), entity.Type)
        );
    }

    public List<KeyDto> build(List<Key> entities)
    {
        return entities.ConvertAll<KeyDto>(build);
    }
}


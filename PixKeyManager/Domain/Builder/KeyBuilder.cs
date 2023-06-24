using PixKeyManager.Data.Model;
using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.Domain.Builder;

public class KeyBuilder: IKeyBuilder
{
    public Key Build(RegisterKeyDto dto, string accountId)
    {
        return new Key
        {
            Value = dto.Value!,
            Type = dto.Type.ToString(),
            AccountId = accountId,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public KeyDto Build(Key entity)
    {
        return new KeyDto
        (
            entity.Id!,
            entity.Value,
            (KeyType) Enum.Parse(typeof(KeyType), entity.Type),
            entity.CreatedAt
        );
    }

    public List<KeyDto> Build(List<Key> entities)
    {
        return entities.ConvertAll(Build);
    }

    public RegisterKeyResultDto BuildResult(Key entity)
    {
        return new RegisterKeyResultDto (
           entity.Value,
           (KeyType)Enum.Parse(typeof(KeyType), entity.Type),
           entity.CreatedAt
        );
    }
}


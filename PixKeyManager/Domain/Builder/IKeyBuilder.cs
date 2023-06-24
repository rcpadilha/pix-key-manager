using PixKeyManager.Data.Model;
using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.Domain.Builder;

public interface IKeyBuilder
{
    Key Build(RegisterKeyDto dto, string accountId);

    KeyDto Build(Key entity);

    List<KeyDto> Build(List<Key> entities);

    RegisterKeyResultDto BuildResult(Key entity);
}


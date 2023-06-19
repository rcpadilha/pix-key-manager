using System;
using PixKeyManager.Data.Model;
using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.Domain.Builder;

public interface IKeyBuilder
{
    Key build(RegisterKeyDto dto);

    KeyDto build(Key entity);

    List<KeyDto> build(List<Key> entities);
}


using System;
using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Builder;
using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.UseCase.Keys;

public class ListKeysByAccountUseCase: IListKeysByAccountUseCase
{
    private readonly IKeyBuilder _keyBuilder;
    private readonly IKeyRepository _keyRepository;

    public ListKeysByAccountUseCase(IKeyBuilder keyBuilder, IKeyRepository keyRepository)
    {
        this._keyBuilder = keyBuilder;
        this._keyRepository = keyRepository;
    }

    public List<KeyDto> execute(string accountId)
    {
        var keys = _keyRepository.FindByAccount(accountId);
        return _keyBuilder.build(keys);
    }
}



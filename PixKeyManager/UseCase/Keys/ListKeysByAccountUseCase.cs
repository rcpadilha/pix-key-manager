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
        _keyBuilder = keyBuilder;
        _keyRepository = keyRepository;
    }

    public List<KeyDto> Execute(string accountId)
    {
        var keys = _keyRepository.FindByAccount(accountId);
        return _keyBuilder.Build(keys);
    }
}



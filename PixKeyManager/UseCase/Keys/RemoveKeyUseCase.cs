using PixKeyManager.Data.Repository;
using PixKeyManager.Exceptions;

namespace PixKeyManager.UseCase.Keys;

public class RemoveKeyUseCase: IRemoveKeyUseCase
{
    private readonly IKeyRepository _keyRepository;

    public RemoveKeyUseCase(IKeyRepository keyRepository)
    {
        _keyRepository = keyRepository;
    }

    public void Execute(string id)
    {
        var key = _keyRepository.FindById(id);

        if (key != null)
        {
            _keyRepository.Delete(key);
            return;
        }

        throw new PixKeyNotFoundException();
    }
}


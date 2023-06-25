using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Validators;

namespace PixKeyManager.UseCase.Keys;

public class RemoveKeyUseCase: IRemoveKeyUseCase
{
    private readonly IKeyRepository _keyRepository;
    private readonly IKeyOwnershipValidator _keyOwnershipValidator;

    public RemoveKeyUseCase(IKeyRepository keyRepository,
                            IKeyOwnershipValidator keyOwnershipValidator)
    {
        _keyRepository = keyRepository;
        _keyOwnershipValidator = keyOwnershipValidator;
    }

    public void Execute(string accountId, string keyId)
    {
        var key = _keyRepository.FindById(keyId);

        _keyOwnershipValidator.Validate(key, accountId);
        _keyRepository.Delete(key!);
    }
}


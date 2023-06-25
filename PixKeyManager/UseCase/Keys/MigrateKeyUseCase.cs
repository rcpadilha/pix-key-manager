using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Model.Key;
using PixKeyManager.Domain.Validators;

namespace PixKeyManager.UseCase.Keys;

public class MigrateKeyUseCase : IMigrateKeyUseCase
{
    private readonly IKeyRepository _keyRepository;
    private readonly IKeyOwnershipValidator _keyOwnershipValidator;

    public MigrateKeyUseCase(IKeyRepository keyRepository,
        IKeyOwnershipValidator keyOwnershipValidator)
    {
        _keyRepository = keyRepository;
        _keyOwnershipValidator = keyOwnershipValidator;
    }

    public void Execute(MigrateKeyDto migrateKey, string accountId)
    {
        var key = _keyRepository.FindByValue(migrateKey.Value);
        _keyOwnershipValidator.Validate(key, accountId);

        key!.AccountId = migrateKey.AccountId;
        _keyRepository.Update(key);
    }
}


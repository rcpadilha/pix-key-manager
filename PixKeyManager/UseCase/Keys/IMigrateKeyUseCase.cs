
using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.UseCase.Keys;

public interface IMigrateKeyUseCase
{
    void Execute(MigrateKeyDto migrateKey, string accountId);
}


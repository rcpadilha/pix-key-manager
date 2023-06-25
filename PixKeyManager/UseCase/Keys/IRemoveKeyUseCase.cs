namespace PixKeyManager.UseCase.Keys;

public interface IRemoveKeyUseCase
{
    void Execute(string accountId, string keyId);
}



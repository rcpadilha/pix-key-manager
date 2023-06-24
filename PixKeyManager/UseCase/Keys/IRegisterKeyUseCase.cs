using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.UseCase.Keys;

public interface IRegisterKeyUseCase
{
    RegisterKeyResultDto Execute(RegisterKeyDto key, string accountId);
}


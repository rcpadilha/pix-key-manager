using PixKeyManager.Domain.Model.Account;

namespace PixKeyManager.UseCase.Account;

public interface IRegisterAccountUseCase
{
    void Execute(RegisterAccountDto accountData);
}


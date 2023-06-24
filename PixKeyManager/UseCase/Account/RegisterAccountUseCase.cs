using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Builder;
using PixKeyManager.Domain.Model.Account;

namespace PixKeyManager.UseCase.Account;

public class RegisterAccountUseCase : IRegisterAccountUseCase
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountBuilder _builder;

    public RegisterAccountUseCase(IAccountRepository accountRepository, IAccountBuilder builder)
    {
        _accountRepository = accountRepository;
        _builder = builder;
    }

    public void Execute(RegisterAccountDto accountData)
    {
        var account = _builder.Build(accountData);
        _accountRepository.Save(account);
    }
}


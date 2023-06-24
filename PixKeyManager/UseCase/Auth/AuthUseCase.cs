using BC = BCrypt.Net.BCrypt;
using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Model.Auth;
using PixKeyManager.Exceptions;
using PixKeyManager.Utils.Jwt;

namespace PixKeyManager.UseCase.Auth;

public class AuthUseCase: IAuthUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;   
    private readonly IJwtTokenUtils _tokenUtils;

    public AuthUseCase(IUserRepository userRepository,
                       IAccountRepository accountRepository,
                       IJwtTokenUtils tokenUtils)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _tokenUtils = tokenUtils;
    }

    public AuthResultDto Execute(AuthDto auth)
    {
        var user = _userRepository.Find(auth.Login);

        if (user == null || !BC.Verify(auth.Password, user.Password)) {
            throw new AuthException();
        }

        var account = _accountRepository.GetAccount(user.Id!);
        return _tokenUtils.BuildToken(user, account);
    }
}


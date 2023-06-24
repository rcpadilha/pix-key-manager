using PixKeyManager.Domain.Model.Auth;

namespace PixKeyManager.UseCase.Auth;

public interface IAuthUseCase
{
    AuthResultDto Execute(AuthDto auth);
}


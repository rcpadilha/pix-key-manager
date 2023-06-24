using PixKeyManager.Data.Model;
using PixKeyManager.Domain.Model.Auth;

namespace PixKeyManager.Utils.Jwt;

public interface IJwtTokenUtils
{
    AuthResultDto BuildToken(User user, Account account);
}


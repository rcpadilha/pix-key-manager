using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PixKeyManager.Data.Model;
using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Model.Auth;
using PixKeyManager.Exceptions;
using PixKeyManager.Utils.Jwt;

namespace PixKeyManager.UseCase.Auth;

public class AuthUseCase: IAuthUseCase
{
    private IUserRepository _userRepository;
    private IJwtTokenUtils _tokenUtils;

    public AuthUseCase(IUserRepository userRepository,
                       IJwtTokenUtils tokenUtils)
    {
        this._userRepository = userRepository;
        this._tokenUtils = tokenUtils;
    }

    public AuthResultDto Execute(AuthDto auth)
    {
        var user = _userRepository.Find(auth.Login, auth.Password);

        if (user != null)
        {
            return _tokenUtils.BuildToken(user);
        }

        throw new AuthException();
    }
}


using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PixKeyManager.Data.Model;
using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Model.Auth;
using PixKeyManager.Exceptions;

namespace PixKeyManager.UseCase.Auth;

public class AuthUseCase: IAuthUseCase
{
    private IUserRepository _userRepository;
    private IConfiguration _configuration;

    public AuthUseCase(IUserRepository userRepository,
                       IConfiguration configuration)
    {
        this._userRepository = userRepository;
        this._configuration = configuration;
    }

    public AuthResultDto Execute(AuthDto auth)
    {
        var user = _userRepository.Find(auth.Login, auth.Password);

        if (user != null)
        {
            return buildToken(user);
        }

        throw new AuthException();
    }

    private AuthResultDto buildToken(User user)
    {
        var jwtConfig = _configuration.GetSection("Jwt");

        var issuer = jwtConfig.GetValue<string>("Issuer");
        var audience = jwtConfig.GetValue<string>("Audience");

        var key = jwtConfig.GetValue<string>("Key")!;
        var keyBytes = Encoding.ASCII.GetBytes(key);
        var duration = jwtConfig.GetValue<int>("Duration");

        var issuedAt = DateTime.Now;
        var expiresIn = issuedAt.AddMinutes(duration);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Login)
            }),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha512Signature),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwtToken = tokenHandler.WriteToken(token);

        return new AuthResultDto {
            Token = jwtToken,
            IssuedAt = issuedAt,
            ExpiresIn = expiresIn,
        };
    }
}


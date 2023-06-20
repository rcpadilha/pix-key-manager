using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PixKeyManager.Data.Model;
using PixKeyManager.Domain.Model.Auth;

namespace PixKeyManager.Utils.Jwt;

public class JwtTokenUtils: IJwtTokenUtils
{
    private AuthConfigDto authConfig;

    public JwtTokenUtils(IConfiguration configuration)
    {
        this.authConfig = configuration.GetSection("Jwt").Get<AuthConfigDto>()!;
    }

    public AuthResultDto BuildToken(User user)
    {
        var issuedAt = DateTime.Now;
        var expiresIn = issuedAt.AddMinutes(authConfig.Duration);

        var tokenDescriptor = buildTokenDescriptor(user, issuedAt, expiresIn);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwtToken = tokenHandler.WriteToken(token);

        return new AuthResultDto
        {
            Token = jwtToken,
            IssuedAt = issuedAt,
            ExpiresIn = expiresIn,
        };
    }

    private SecurityTokenDescriptor buildTokenDescriptor(
        User user, DateTime issuedAt, DateTime expiresIn)
    {
        var keyBytes = Encoding.ASCII.GetBytes(authConfig.Key);

        return new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Login)
            }),

            Expires = expiresIn,
            IssuedAt = issuedAt,
            NotBefore = issuedAt,

            Issuer = authConfig.Issuer,
            Audience = authConfig.Audience,

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha512Signature),
        };

    }
}


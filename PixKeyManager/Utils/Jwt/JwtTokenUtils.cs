using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PixKeyManager.Data.Model;
using PixKeyManager.Domain.Model.Auth;
using PixKeyManager.Utils.Constants;

namespace PixKeyManager.Utils.Jwt;

public class JwtTokenUtils: IJwtTokenUtils
{
    private readonly AuthConfigDto _authConfig;

    public JwtTokenUtils(IConfiguration configuration)
    {
        _authConfig = configuration.GetSection(IConstants.JWT_SECTION).Get<AuthConfigDto>()!;
    }

    public AuthResultDto BuildToken(User user, Account account)
    {
        var issuedAt = DateTime.Now;
        var expiresIn = issuedAt.AddMinutes(_authConfig.Duration);

        var tokenDescriptor = BuildTokenDescriptor(user, account, issuedAt, expiresIn);

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

    private SecurityTokenDescriptor BuildTokenDescriptor(
        User user, Account account, DateTime issuedAt, DateTime expiresIn)
    {
        var keyBytes = Encoding.ASCII.GetBytes(_authConfig.Key);

        return new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Login),
                new Claim(IConstants.CLAIM_ACCOUNT_ID, account.Id!)
            }),

            Expires = expiresIn,
            IssuedAt = issuedAt,
            NotBefore = issuedAt,

            Issuer = _authConfig.Issuer,
            Audience = _authConfig.Audience,

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha512Signature),
        };

    }
}


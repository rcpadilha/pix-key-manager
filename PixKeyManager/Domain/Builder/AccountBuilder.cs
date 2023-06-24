using BC = BCrypt.Net.BCrypt;
using PixKeyManager.Data.Model;
using PixKeyManager.Domain.Model.Account;

namespace PixKeyManager.Domain.Builder;

public class AccountBuilder: IAccountBuilder
{
    public AccountBuilder()
    {
    }

    public Account Build(RegisterAccountDto dto)
    {
        return new Account
        {
            Number = new Random().Next(10000, 99999).ToString(),
            User = new User {
                Login = dto.Login,
                Password = BC.HashPassword(dto.Password)
            }
        };
    }
}


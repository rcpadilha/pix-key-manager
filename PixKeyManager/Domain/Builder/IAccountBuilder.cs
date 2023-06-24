using PixKeyManager.Data.Model;
using PixKeyManager.Domain.Model.Account;

namespace PixKeyManager.Domain.Builder;

public interface IAccountBuilder
{
    Account Build(RegisterAccountDto dto);
}


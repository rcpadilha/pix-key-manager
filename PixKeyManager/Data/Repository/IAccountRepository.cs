using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Repository;

public interface IAccountRepository
{
    Account GetAccount(string userId);

    void Save(Account account);
}


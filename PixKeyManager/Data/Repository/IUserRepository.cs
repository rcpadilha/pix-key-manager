using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Repository;

public interface IUserRepository
{
    User? Find(string login);
}

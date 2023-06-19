using System;
using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Repository;

public interface IUserRepository
{
    User? Find(String login, String password);
}

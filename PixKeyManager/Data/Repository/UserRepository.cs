using System;
using PixKeyManager.Data.Context;
using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Repository;

public class UserRepository: IUserRepository
{
    private readonly PixKeyContext _context;

    public UserRepository(PixKeyContext context)
    {
        this._context = context;
    }

    public User? Find(string login, string password)
    {
        var user = this._context.Users.SingleOrDefault(
            user => user.Login == login && user.Password == password);

        return user;
    }
}


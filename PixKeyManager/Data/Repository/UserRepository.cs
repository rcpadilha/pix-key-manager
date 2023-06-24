using Microsoft.EntityFrameworkCore;
using PixKeyManager.Data.Context;
using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Repository;

public class UserRepository: IUserRepository
{
    private readonly PixKeyContext _context;

    public UserRepository(PixKeyContext context)
    {
        _context = context;
    }

    public User? Find(string login)
    {
        var user = _context.Users
            .AsNoTracking()
            .SingleOrDefault(
                user => user.Login == login);

        return user;
    }
}


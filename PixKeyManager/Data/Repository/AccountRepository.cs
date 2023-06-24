using Microsoft.EntityFrameworkCore;
using PixKeyManager.Data.Context;
using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly PixKeyContext _context;

    public AccountRepository(PixKeyContext context)
    {
        _context = context;
    }

    public Account GetAccount(string userId)
    {
        return _context.Accounts
            .AsNoTracking()
            .Single(account => account.UserId == userId);
    }

    public void Save(Account account)
    {
        _context.Accounts.Add(account);
        _context.SaveChanges();
    }
}


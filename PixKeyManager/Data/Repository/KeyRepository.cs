using Microsoft.EntityFrameworkCore;
using PixKeyManager.Data.Context;
using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Repository;

public class KeyRepository: IKeyRepository
{
    private readonly PixKeyContext _context;

	public KeyRepository(PixKeyContext context)
	{
        this._context = context;
	}

    public List<Key> FindByAccount(string accountId)
    { 
        return _context.Keys
            .AsNoTracking()
            .Where(key => key.AccountId == accountId)
            .ToList();
    }

    public Key? FindById(string id)
    {
        return _context.Keys
            .AsNoTracking()
            .SingleOrDefault(k => k.Id == id);
    }

    public Key? FindByValue(string value)
    {
        return _context.Keys
            .AsNoTracking()
            .SingleOrDefault(k =>
                k.Value == value);
    }

    public void Save(Key key)
    {
        _context.Keys.Add(key);
        _context.SaveChanges();
    }

    public void Delete(Key key)
    {
        _context.Keys.Remove(key);
        _context.SaveChanges();
    }

    public void Update(Key key)
    {
        _context.Keys.Remove(key);
        _context.SaveChanges();
    }
}


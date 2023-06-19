using System;
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
            .Where(key => key.AccountId == accountId)
            .ToList();
    }

    public void Save(Key key)
    {
        _context.Keys.Add(key);
        _context.SaveChanges();
    }

    public Key? FindById(string id)
    {
        return _context.Keys.SingleOrDefault(k => k.Id == id);
    }

    public void Delete(Key key)
    {
        _context.Keys.Remove(key);
        _context.SaveChanges();
    }

}


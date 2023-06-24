using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Repository;

public interface IKeyRepository
{
    void Save(Key key);

    List<Key> FindByAccount(string accountId);

    Key? FindById(string id);

    void Delete(Key key);
}


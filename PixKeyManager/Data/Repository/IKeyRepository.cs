using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Repository;

public interface IKeyRepository
{
    void Save(Key key);

    List<Key> FindByAccount(string accountId);

    Key? FindByValue(string value);

    Key? FindById(string id);

    void Delete(Key key);

    void Update(Key key);
}


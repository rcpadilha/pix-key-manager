using PixKeyManager.Data.Model;

namespace PixKeyManager.Domain.Validators;

public interface IKeyOwnershipValidator
{

    void Validate(Key? key, string accountId);

}


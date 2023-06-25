using PixKeyManager.Data.Model;
using PixKeyManager.Exceptions;

namespace PixKeyManager.Domain.Validators;

public class KeyOwnershipValidator : IKeyOwnershipValidator
{
    public void Validate(Key? key, string accountId)
    {
        if (key == null)
        {
            throw new KeyNotFoundException();
        }

        if (key.AccountId != accountId)
        {
            throw new KeyNotFromAccountException();
        }
    }
}


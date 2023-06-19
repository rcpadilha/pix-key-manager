using System;
using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.UseCase.Keys;

public interface IListKeysByAccountUseCase
{
    List<KeyDto> execute(String accountId);
}

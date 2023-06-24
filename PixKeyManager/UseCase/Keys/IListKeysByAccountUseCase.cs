using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.UseCase.Keys;

public interface IListKeysByAccountUseCase
{
    List<KeyDto> Execute(string accountId);
}

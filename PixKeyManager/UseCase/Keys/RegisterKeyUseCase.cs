using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Builder;
using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.UseCase.Keys;

public class RegisterKeyUseCase: IRegisterKeyUseCase
{
    private readonly IKeyBuilder _builder;
    private readonly IKeyRepository _repository;

	public RegisterKeyUseCase(IKeyBuilder builder, IKeyRepository repository)
	{
        _builder = builder;
        _repository = repository;
	}

    public RegisterKeyResultDto Execute(RegisterKeyDto key, string accountId)
    {
        if (key.Type == KeyType.EVP) {
            key.Value = Guid.NewGuid().ToString();
        }

        var entity = _builder.Build(key, accountId);
        _repository.Save(entity);

        return _builder.BuildResult(entity);
    }
}

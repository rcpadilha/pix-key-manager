using System;
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
        this._builder = builder;
        this._repository = repository;
	}

    public void execute(RegisterKeyDto key)
    {
        var entity = _builder.build(key);
        _repository.Save(entity);
    }
}

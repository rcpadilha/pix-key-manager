using System;
using PixKeyManager.Domain.Model.Key;

namespace PixKeyManager.UseCase.Keys;

public interface IRegisterKeyUseCase
{
    void execute(RegisterKeyDto key);
}


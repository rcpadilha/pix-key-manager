using System.Net;

namespace PixKeyManager.Exceptions;

public class PixKeyNotFoundException: BaseHttpException
{
    public PixKeyNotFoundException():
        base(HttpStatusCode.NotFound, "Chave não encontrada")
    {
    }
}


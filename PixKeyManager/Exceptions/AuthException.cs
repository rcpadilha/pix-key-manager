using System.Net;

namespace PixKeyManager.Exceptions;

public class AuthException: BaseHttpException
{
    public AuthException():
        base(HttpStatusCode.Unauthorized, "Dados inválidos para o login")
    {
    }
}


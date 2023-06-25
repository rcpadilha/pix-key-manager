using System.Net;

namespace PixKeyManager.Exceptions;

public class KeyNotFromAccountException : BaseHttpException
{
    public KeyNotFromAccountException():
        base(HttpStatusCode.Forbidden, "A chave envolvida nesta operação não é da propriedade do usuário requisitante.")
    {
    }
}


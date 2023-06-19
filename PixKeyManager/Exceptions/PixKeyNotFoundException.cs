using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace PixKeyManager.Exceptions;

public class PixKeyNotFoundException: BaseHttpException
{
    public PixKeyNotFoundException():
        base(HttpStatusCode.NotFound, "Chave não encontrada")
    {
    }
}


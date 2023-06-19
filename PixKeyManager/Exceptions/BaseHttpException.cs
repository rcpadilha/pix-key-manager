using System;
using System.Net;

namespace PixKeyManager.Exceptions;

public abstract class BaseHttpException: Exception
{
    public HttpStatusCode StatusCode { get;  }

    public BaseHttpException(HttpStatusCode statusCode,
        String message): base(message)
    {
        this.StatusCode = statusCode;
    }
}

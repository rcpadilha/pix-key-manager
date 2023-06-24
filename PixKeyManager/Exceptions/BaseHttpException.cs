using System.Net;

namespace PixKeyManager.Exceptions;

public abstract class BaseHttpException: Exception
{
    public HttpStatusCode StatusCode { get;  }

    public BaseHttpException(HttpStatusCode statusCode,
        string message): base(message)
    {
        StatusCode = statusCode;
    }
}

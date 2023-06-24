namespace PixKeyManager.Domain.Model.Base;

public class ErrorResultDto
{
    public string Message { get; }

    public ErrorResultDto(string message)
    {
        Message = message;
    }
}

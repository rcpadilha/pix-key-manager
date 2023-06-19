using System;
namespace PixKeyManager.Domain.Model.Base;

public class ErrorResultDto
{
    public String Message { get; }

    public ErrorResultDto(string message)
    {
        this.Message = message;
    }
}

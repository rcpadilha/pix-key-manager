using System;
namespace PixKeyManager.Domain.Model.Auth;

public class AuthDto
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}


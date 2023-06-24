namespace PixKeyManager.Domain.Model.Auth;

public class AuthResultDto
{
    public required string Token { get; set; }
    public required DateTime IssuedAt { get; set; }
    public required DateTime ExpiresIn { get; set; }
}


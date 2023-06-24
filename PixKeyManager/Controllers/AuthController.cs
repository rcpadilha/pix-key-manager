using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PixKeyManager.Domain.Model.Auth;
using PixKeyManager.UseCase.Auth;

namespace PixKeyManager.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class AuthController: Controller
{
    private readonly IAuthUseCase _auth;

    public AuthController(IAuthUseCase auth)
    {
        _auth = auth;
    }

    [HttpPost]
    public IActionResult Authenticate(AuthDto authData)
    {
        var authResult = _auth.Execute(authData);
        return Ok(authResult);
    }

}


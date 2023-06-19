using System;
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
        this._auth = auth;
    }

    [HttpPost]
    public IActionResult authenticate(AuthDto authData)
    {
        var authResult = _auth.Execute(authData);
        return Ok(authResult);
    }

}


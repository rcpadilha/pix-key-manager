using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PixKeyManager.Domain.Model.Key;
using PixKeyManager.UseCase.Keys;

namespace PixKeyManager.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class KeyController : Controller
{
	private readonly IRegisterKeyUseCase _registerKey;
    private readonly IListKeysByAccountUseCase _listKeysByAccount;
    private readonly IRemoveKeyUseCase _removeKey;

    public KeyController(IRegisterKeyUseCase registerKey,
                         IListKeysByAccountUseCase listKeysByAccount,
                         IRemoveKeyUseCase removeKey)
    {
        this._registerKey = registerKey;
        this._listKeysByAccount = listKeysByAccount;
        this._removeKey = removeKey;
    }

    [HttpPost]
    public IActionResult save(RegisterKeyDto key)
    {
        _registerKey.execute(key);
        return Ok();
    }
    
    [HttpGet("account/{accountId}")]
    public IActionResult listByAccount(String accountId)
    {
        var result = _listKeysByAccount.execute(accountId);
        return result.Count != 0 ? Ok(result) : NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult removeKey(String id)
    {
        _removeKey.execute(id);
        return Ok();
    }
}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PixKeyManager.Domain.Model.Key;
using PixKeyManager.UseCase.Keys;

namespace PixKeyManager.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class KeysController : BaseController
{
	private readonly IRegisterKeyUseCase _registerKey;
    private readonly IListKeysByAccountUseCase _listKeysByAccount;
    private readonly IRemoveKeyUseCase _removeKey;
    private readonly IMigrateKeyUseCase _migrateKey;

    public KeysController(IRegisterKeyUseCase registerKey,
                         IListKeysByAccountUseCase listKeysByAccount,
                         IRemoveKeyUseCase removeKey,
                         IMigrateKeyUseCase migrateKey) : base()
    {
        _registerKey = registerKey;
        _listKeysByAccount = listKeysByAccount;
        _removeKey = removeKey;
        _migrateKey = migrateKey;
    }

    [HttpPost]
    public IActionResult Save(RegisterKeyDto key)
    {
        var result = _registerKey.Execute(key, UserAccountId!);
        return Ok(result);
    }
    
    [HttpGet]
    public IActionResult List()
    {
        var result = _listKeysByAccount.Execute(UserAccountId!);
        return result.Count != 0 ? Ok(result) : NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveKey(string id)
    {
        _removeKey.Execute(UserAccountId!, id);
        return Ok();
    }

    [HttpPut]
    public IActionResult MigrateKey(MigrateKeyDto key) {
        _migrateKey.Execute(key, UserAccountId!);
        return Ok();      
    }
}


using Microsoft.AspNetCore.Mvc;
using PixKeyManager.Domain.Model.Account;
using PixKeyManager.UseCase.Account;

namespace PixKeyManager.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : Controller
{
	private readonly IRegisterAccountUseCase _registerAccount;

    public AccountsController(IRegisterAccountUseCase registerAccount): base()
    {
        _registerAccount = registerAccount;
    }

    [HttpPost]
    public IActionResult Save(RegisterAccountDto account)
    {
        _registerAccount.Execute(account);
        return Ok();
    }    
}


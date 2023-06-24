using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PixKeyManager.Utils.Constants;

namespace PixKeyManager.Controllers;

public abstract class BaseController: Controller
{
    protected string? UserAccountId {
        get {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return identity?.FindFirst(IConstants.CLAIM_ACCOUNT_ID)?.Value;
        }
    }
}

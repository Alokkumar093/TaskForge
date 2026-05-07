using Microsoft.AspNetCore.Mvc;

namespace TaskForge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController : ControllerBase
{
    /// <summary>Placeholder for login / refresh flows.</summary>
    [HttpPost("login")]
    public ActionResult Login()
    {
        return StatusCode(StatusCodes.Status501NotImplemented, new { message = "Authentication scaffold — add JWT or OpenID Connect." });
    }
}

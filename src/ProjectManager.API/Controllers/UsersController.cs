using Microsoft.AspNetCore.Mvc;

namespace TaskForge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController : ControllerBase
{
    /// <summary>Placeholder for profile and membership endpoints.</summary>
    [HttpGet("me")]
    public ActionResult<object> Me()
    {
        return Ok(new { message = "Users API scaffold — wire authentication next." });
    }
}

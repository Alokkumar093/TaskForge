using Microsoft.AspNetCore.Mvc;

namespace TaskForge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ReportsController : ControllerBase
{
    /// <summary>Placeholder for burndown / workload reports.</summary>
    [HttpGet("summary")]
    public ActionResult<object> Summary()
    {
        return Ok(new { message = "Reports API scaffold — connect to analytics queries later." });
    }
}

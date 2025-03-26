using Microsoft.AspNetCore.Mvc;
using MouseTracker.Application.Dtos;
using MouseTracker.Application.MouseTrack;

namespace MouseTracker.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class MouseTrackController : ControllerBase
{
    [HttpGet("page")]
    public IActionResult GetPage()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] IEnumerable<MouseMovementDto> movements,
        [FromServices] CreateMouseTrackHandler handler,
        CancellationToken cancellationToken)
    {
        var command = new CreateMouseTrackCommand(movements);
        var result = await handler.Handle(command,cancellationToken);
        return Ok(result);
    }
}
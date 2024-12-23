using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("/pageview")]
public class PageViewController(IPageViewService pageViewService) : ControllerBase
{
    [HttpPost("batch")]
    public async Task<IActionResult> PageViews([FromBody] string[] slugs)
    {
        var blogs = await pageViewService.GetBatchAsync(slugs);

        return Ok(blogs);
    }
}
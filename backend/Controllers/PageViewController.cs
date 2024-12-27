using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace backend.Controllers;

[EnableRateLimiting("fixed")]
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
    
    [HttpPost("increment")]
    public async Task<IActionResult> PageViews([FromBody] string slug)
    {
        var blog = await pageViewService.IncrementAsync(slug);
        return Ok(blog);
    }
}
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("/blogs")]
public class BlogsController(IBlogService blogService) : ControllerBase
{
    [HttpPatch("{slug}/likes")]
    public async Task<IActionResult> UpdateLikes(string slug)
    {
        var blog = await blogService.IncrementLikesAsync(slug);
        return Ok(blog);
    }
    
    
    [HttpGet("{slug}/likes")]
    public async Task<IActionResult> GetLikes(string slug)
    {
        var blog = await blogService.GetLikesAsync(slug);
        return Ok(blog);
    }
}
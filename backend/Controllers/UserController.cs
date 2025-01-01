using System.Security.Claims;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("user")]
public class UserController (UserService userService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetUserData()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        if (string.IsNullOrEmpty(email))
        {
            return Unauthorized("No email found in token claims");
        }

        var user = await userService.GetUserByEmailAsync(email);
        if (user == null)
        {
            return NotFound($"No user found with email: {email}");
        }
        
        return Ok(user);
    }
}
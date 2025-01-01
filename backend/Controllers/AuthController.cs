using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.IdentityModel.Tokens;


[ApiController]
[Route("auth")]
public class AuthController (AppDbContext dbContext, IConfiguration configuration, IWebHostEnvironment environment) : Controller
{
    [HttpGet("google-login")]
    public IActionResult GoogleLogin(string returnUrl)
    {
        var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleCallback") };
        properties.Items["returnUrl"] = returnUrl;
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("google-callback")]
    public async Task<IActionResult> GoogleCallback()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (result?.Succeeded != true)
        {
            return BadRequest("Authentication failed");
        }

        var returnUrl = result.Properties.Items["returnUrl"] ?? "/";
        var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
        var name = result.Principal.FindFirst(ClaimTypes.Name)?.Value;

        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email); 
        if (user is null)
        {
            user = new User
            {
                Email = email ?? string.Empty,
                Username = name ?? string.Empty,
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var token = GenerateToken(claims);
        
        return Redirect($"{returnUrl}?token={token}");
    }
    
    private string GenerateToken(IEnumerable<Claim> claims)
    {
        var jwtKey = environment.IsDevelopment()
            ? configuration["Authentication:Jwt:Key"]
            : Environment.GetEnvironmentVariable("JWT_KEY");
        
        var issuer = environment.IsDevelopment()
            ? configuration["Authentication:Jwt:Issuer"]
            : Environment.GetEnvironmentVariable("JWT_ISSUER");
        
        var audience = environment.IsDevelopment()
            ? configuration["Authentication:Jwt:Audience"]
            : Environment.GetEnvironmentVariable("JWT_AUDIENCE");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey ?? 
                                                                  throw new InvalidOperationException("JWT key not configured")));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
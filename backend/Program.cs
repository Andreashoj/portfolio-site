using System.Text;
using System.Threading.RateLimiting;
using backend.data;
using backend.Services;
using backend.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString;
    
    if (builder.Environment.IsDevelopment())
    {
        connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    }
    else
    {
        connectionString = $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
                           $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
                           $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                           $"Database={Environment.GetEnvironmentVariable("DB_NAME")}";
    }
    
    options.UseNpgsql(connectionString);
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddJwtBearer(options =>
    {
        var jwtKey = builder.Environment.IsDevelopment()
            ? builder.Configuration["Authentication:Jwt:Key"]
            : Environment.GetEnvironmentVariable("JWT_KEY");

        var issuer = builder.Environment.IsDevelopment()
            ? builder.Configuration["Authentication:Jwt:Issuer"]
            : Environment.GetEnvironmentVariable("JWT_ISSUER");

        var audience = builder.Environment.IsDevelopment()
            ? builder.Configuration["Authentication:Jwt:Audience"]
            : Environment.GetEnvironmentVariable("JWT_AUDIENCE");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey))
        };
    })
    .AddGoogle(options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
        }
        else
        {
            options.ClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
            options.ClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");
        }
    });
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Services
builder.Services.AddScoped<IPageViewService, PageViewService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<UserService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            policy.WithOrigins("http://localhost:5000");
        });
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = 429; // Too Many Requests
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.PermitLimit = 100;
        opt.Window = TimeSpan.FromMinutes(1);  
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 0;  
    });
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
await db.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.UseApiKeyMiddleware();
app.UseRateLimiter();

app.Run();

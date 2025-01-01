namespace backend.Middlewares;

public class ApiKeyMiddleware(RequestDelegate next, IWebHostEnvironment env)
{
    private const string APIKEY = "X-Api-Key";
    private readonly string[] _excludedPaths = new[] { "/auth/google-login", "/auth/google-callback" };

    public async Task InvokeAsync(HttpContext context)
    {
        // Skip API key check for excluded paths
        if (_excludedPaths.Any(path => context.Request.Path.Value != null && context.Request.Path.Value.EndsWith(path)))
        {
            await next(context);
            return;
        }
        
        if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key was not provided hello");
            return;
        }

        string apiKey;
        if (env.IsDevelopment())
        {
            // Get from appsettings.json in development
            var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
            apiKey = configuration["ApiKey"];
        }
        else
        {
            // Get from environment variable in production
            apiKey = Environment.GetEnvironmentVariable("PUBLIC_API_KEY");
        }

        if (!apiKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized client");
            return;
        }

        await next(context);
    }
}
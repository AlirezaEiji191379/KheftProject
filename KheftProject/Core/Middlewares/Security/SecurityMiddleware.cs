using System.Text;
using Newtonsoft.Json;

namespace KheftProject.Core.Middlewares.Security;

public class SecurityMiddleware : IMiddleware
{
    private readonly IConfiguration _configuration;

    public SecurityMiddleware(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var secretKey = _configuration.GetValue<string>("AuthKey");
        
        if (!context.Request.Headers.ContainsKey("X-Api-Key"))
        {
            var token1 = context.Request.Headers["X-Api-Key"].FirstOrDefault();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            var message = new { Message = "you do not have token!" };
            var response = JsonConvert.SerializeObject(message);
            context.Response.ContentType = "application/json";
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(response);
            await context.Response.WriteAsync(response);
            return;
        }
        
        var apiKey = context.Request.Headers["X-Api-Key"].FirstOrDefault();
        if (apiKey != secretKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var message = new { Message = "invalid token!" };
            var response = JsonConvert.SerializeObject(message);
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(response);
            await context.Response.WriteAsync(response);
            return;
        }

        await next(context);
    }
}
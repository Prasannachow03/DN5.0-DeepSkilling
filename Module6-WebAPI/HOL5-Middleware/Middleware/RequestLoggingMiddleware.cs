namespace HOL5_Middleware.Middleware;
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"[{DateTime.Now}] {context.Request.Method} {context.Request.Path}");
        await _next(context);
        Console.WriteLine($"[{DateTime.Now}] Response: {context.Response.StatusCode}");
    }
}
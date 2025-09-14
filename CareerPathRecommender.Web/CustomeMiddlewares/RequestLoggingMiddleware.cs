using Serilog;

namespace CareerPathRecommender.Web.CustomeMiddelwre
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var user = context.User.Identity?.Name ?? "Anonymous";
            var path = context.Request.Path;
            var method = context.Request.Method;

            Log.Information("User {User} requested {Method} {Path}", user, method, path);

            try
            {
                await _next(context);
                Log.Information("Request {Method} {Path} completed with status {StatusCode}", method, path, context.Response.StatusCode);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unhandled exception in {Method} {Path} for user {User}", method, path, user);
                throw;
            }
        }
    }

}

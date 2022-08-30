using System.Text;

namespace OpenAPI.Middleware
{
    public class BaseAuthMiddlewave
    {
        private readonly RequestDelegate _next;

        public BaseAuthMiddlewave(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IConfiguration configuration)
        {
            var basicAuthentication = configuration["ApplicationSettings:BaseAuthentication"];
            if (string.IsNullOrWhiteSpace(basicAuthentication))
            {
                await _next(httpContext);
                return;
            }
            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                string auth = authHeader.Split(new char[] { ' ' })[1];
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                var usernameAndPassword = encoding.GetString(Convert.FromBase64String(auth));
                if (basicAuthentication == usernameAndPassword)
                {
                    await _next(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    httpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"" + httpContext.Request.Host + "\"");
                    return;
                }
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"" + httpContext.Request.Host + "\"");
                return;
            }
        }
    }

    public static class BaseAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthMiddleware(this IApplicationBuilder builder, IConfiguration configuration)
        {
            return builder.UseMiddleware<BaseAuthMiddlewave>();
        }
    }

}

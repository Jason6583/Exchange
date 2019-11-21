using Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class DuplicateRequestMiddleware
    {
        private readonly RequestDelegate _next;
        public DuplicateRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
        public async Task Invoke(HttpContext httpContext, IRedisCache redisCache)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            if (redisCache == null)
                throw new ArgumentNullException(nameof(redisCache));

            Task task = null;
            var requestId = httpContext.Request.Headers["x-request-id"];
            if (!string.IsNullOrWhiteSpace(requestId))
            {
                if (((string)requestId).Length > 40)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await httpContext.Response.WriteAsync("Invalid x-request-id. x-request-id can have upto 40 charcters.");
                    return;
                }
                if (redisCache.Exists($"req-{requestId}"))
                {
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                    await httpContext.Response.WriteAsync("{ \"x-request-id\": [ \"duplicate request id.\" ] } ");
                    return;
                }
                else
                {
                    task = redisCache.StringSetAsync($"req-{requestId}", "", TimeSpan.FromMinutes(5));
                }
            }
            await _next(httpContext);
            if (task != null)
                await task;
        }
    }
}

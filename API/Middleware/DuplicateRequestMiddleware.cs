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

        public async Task Invoke(HttpContext httpContext, IRedisCache redisCache)
        {
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
                    task = redisCache.SetAsync($"req-{requestId}", "", TimeSpan.FromMinutes(5));
                }
            }
            await _next(httpContext);
            if (task != null)
                await task;
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Invoke(HttpContext httpContext)
        {
            var requestId = httpContext.Request.Headers["x-request-id"];
            if (!string.IsNullOrWhiteSpace(requestId))
            {

            }
            await _next(httpContext);
        }
    }
}

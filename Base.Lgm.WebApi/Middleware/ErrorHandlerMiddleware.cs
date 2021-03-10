using ExternalBase.Lgm.Utilities.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Lgm.WebApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHttpErrorFactory httpErrorFactory;

        
        public ErrorHandlerMiddleware(RequestDelegate next, IHttpErrorFactory httpErrorFactory)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.httpErrorFactory = httpErrorFactory ?? throw new ArgumentNullException(nameof(httpErrorFactory));
        }
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await CreateHttpError(context, exception);
            }
        }

        private async Task CreateHttpError(HttpContext context, Exception exception)
        {
            var error = httpErrorFactory.CreateFrom(exception);

            await WriteResponseAsync(
                context,
                JsonConvert.SerializeObject(error),
                "application/json",
                error.HttpCode);
        }

        private Task WriteResponseAsync(HttpContext context, string content, string contentType, int statusCode)
        {
            context.Response.Headers["Content-Type"] = new[] { contentType };
            context.Response.Headers["Cache-Control"] = new[] { "no-cache, no-store, must-revalidate" };
            context.Response.Headers["Pragma"] = new[] { "no-cache" };
            context.Response.Headers["Expires"] = new[] { "0" };
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(content);
        }
    }
}

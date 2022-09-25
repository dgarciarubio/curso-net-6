using Microsoft.AspNetCore.Http;
using OrderApp.Domain.Exceptions;
using System.Net;

namespace OrderApp.Api.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await _next.Invoke(context);
            }
            catch (NotFoundException) 
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            catch (CustomerConfigurationException) 
            {
                context.Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
            }
        }
    }
}

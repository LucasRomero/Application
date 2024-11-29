using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;   
        }

        public async Task Invoke(HttpContext context) 
        {

            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsJsonAsync(new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Errors,
                    Timestamp = DateTime.UtcNow
                });

            }

            catch (Exception ex)
            {

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsJsonAsync(new
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Timestamp = DateTime.UtcNow
                });

            }
        }

    }
}

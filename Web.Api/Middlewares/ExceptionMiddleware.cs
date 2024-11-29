using Application.Exceptions;
using System.Net;

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
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, Result<string>.Failure(ex.Message));
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, Result<string>.Failure("Ocurrio un error"));
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, Result<string> message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                Code = statusCode,
                Message = message,
                Timestamp = DateTime.UtcNow
            };

            await context.Response.WriteAsJsonAsync(response);
        }

    }
}

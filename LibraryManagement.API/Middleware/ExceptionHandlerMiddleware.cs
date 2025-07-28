using LibraryManagement.API.Responses;
using LibraryManagement.Main.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace LibraryManagement.API.Middleware
{
    public class ExceptionHandlerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode status = exception switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                ValidationException => HttpStatusCode.BadRequest,
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.InternalServerError
            };

            context.Response.StatusCode = (int)status;

            object result = status switch
            {
                HttpStatusCode.BadRequest when exception is ValidationException ve => new ApiResponse<IEnumerable<string>>
                {
                    Success = false,
                    Message = ve.Message,
                    Data = null,
                },

                _ => new ApiResponse<string>
                {
                    Success = false,
                    Message = exception.Message,
                    Data = null
                }
            };

            var json = JsonSerializer.Serialize(result);

            return context.Response.WriteAsync(json);
        }
    }
}

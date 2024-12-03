using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using Cars.SharedKernel;

namespace Cars.Api.Middleware
{
    public class GlobalExceptionHandler(IAppLogger logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.Error(GetExceptionMessages(exception, Environment.NewLine));

            HttpStatusCode statusCode;
            string message;
            switch (exception) 
            {
                case ArgumentException ex:
                    statusCode = HttpStatusCode.BadRequest; message = $"Invalid argument error: {ex.Message}"; break;
                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized; message = "Resource requires authentication"; break;
                default: 
                    statusCode = HttpStatusCode.InternalServerError; message = "Internal Server Error"; break;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsync($"{new ErrorDetails(statusCode, message)}", cancellationToken);
            return true;
        }

        public static string GetExceptionMessages(Exception exception, string separator)
        {
            var messages = new List<string> { exception.Message };

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                messages.Add(exception.Message);
            }

            return string.Join(separator, messages);
        }
    }

    public class ErrorDetails(HttpStatusCode statusCode, string message)
    {
        public int StatusCode { get; set; } = (int)statusCode;

        public string Message { get; set; } = message;

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}

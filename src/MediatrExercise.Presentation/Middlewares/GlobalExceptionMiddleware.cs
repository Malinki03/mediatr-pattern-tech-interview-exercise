using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MediatrExercise.Presentation.Middlewares;

internal class GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Generic exception occurred");
        var errorResponse = new ProblemDetails
        {
            Title = "Something went wrong",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "A generic exception occurred and we couldn't process your request."
        };
        
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);
        return true;
    }
}
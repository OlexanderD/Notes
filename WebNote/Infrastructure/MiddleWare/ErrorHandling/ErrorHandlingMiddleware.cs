namespace WebNote.Infrastructure.MiddleWare.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;

            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {                
                _logger.LogError(exception, exception.Message);

                context.Response.ContentType = "plain/text";                
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}

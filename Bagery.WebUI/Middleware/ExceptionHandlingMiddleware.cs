namespace Bagery.WebUI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "İşlenmeyen hata yakalandı. Path: {Path}, Method: {Method}, User: {User}",
                    context.Request.Path,
                    context.Request.Method,
                    context.User?.Identity?.Name ?? "Anonymous");

                // APM'e exception gönder
                Elastic.Apm.Agent.Tracer.CurrentTransaction?.CaptureException(ex);

                throw;
            }
        }
    }
}

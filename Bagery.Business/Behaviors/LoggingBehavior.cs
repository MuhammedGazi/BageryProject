using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;
            _logger.LogInformation($"[LOG] İşlem Başlıyor: {requestName}");

            var response = await next();

            _logger.LogInformation($"[LOG] İşlem Tamamlandı: {requestName}");

            return response;
        }
    }
}

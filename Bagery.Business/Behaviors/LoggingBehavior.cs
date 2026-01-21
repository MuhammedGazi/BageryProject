using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

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
            var requestData = JsonSerializer.Serialize(request);

            _logger.LogInformation($"[GİRİŞ] İstek: {requestName} | Veri: {requestData}");

            try
            {
                var response = await next();
                _logger.LogInformation($"[ÇIKIŞ] İstek {requestName} başarıyla tamamlandı.");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[HATA] {requestName} işlenirken bir sorun oluştu! Hata Detayı: {ex.Message}");
                throw;
            }
        }
    }
}

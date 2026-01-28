using Microsoft.Extensions.Logging;

namespace Bagery.DataAccess.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogBusinessInfo(this ILogger logger, string message, params object[] args)
        {
            logger.LogInformation($"[BUSINESS] {message}", args);
        }

        public static void LogDataAccess(this ILogger logger, string message, params object[] args)
        {
            logger.LogInformation($"[DATA] {message}", args);
        }

        public static void LogPerformance(this ILogger logger, string operation, long milliseconds)
        {
            logger.LogInformation($"[PERFORMANCE] {operation} tamamlandı. Süre: {milliseconds}ms");
        }
    }
}

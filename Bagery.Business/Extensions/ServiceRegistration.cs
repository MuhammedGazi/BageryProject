using Bagery.Business.Behaviors;
using Bagery.Business.Observers;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Business.Services.IAuthServices;
using Bagery.Core.Interfaces.Observer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bagery.Business.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            });
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            services.AddScoped<IAuthServices, AuthServices>();

            services.AddScoped<INotificationSubject, NotificationSubject>();

            services.AddScoped<NotificationObserver>();

            return services;
        }
    }
}

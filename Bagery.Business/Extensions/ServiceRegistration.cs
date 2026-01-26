using Bagery.Business.Behaviors;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Business.Services.IAuthServices;
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

            return services;
        }
    }
}

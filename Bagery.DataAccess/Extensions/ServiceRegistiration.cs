using Bagery.Core.Interfaces.Repositories;
using Bagery.DataAccess.Concrete.EntityFramework;
using Bagery.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bagery.DataAccess.Extensions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddDataAccessExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}

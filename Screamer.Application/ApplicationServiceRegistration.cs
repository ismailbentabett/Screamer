using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Screamer.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
                    services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly()
                ));

            return services;
        }

    }
}
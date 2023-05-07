using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance
{
    public static class PresistanceServiceRegistration
    {
        public static IServiceCollection AddPresistanceServices(this IServiceCollection services,
                //config
                IConfiguration
                Configuration
        )
        {

            services.AddDbContext<ScreamerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ScreamerDbConnection")));


            return services;
        }

    }
}
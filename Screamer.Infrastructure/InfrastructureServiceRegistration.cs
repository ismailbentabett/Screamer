using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Screamer.Application.Contracts.Email;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Models.Email;
using Screamer.Infrastructure.EmailService;
using Screamer.Infrastructure.Logging;

namespace Screamer.Presistance
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                //config
                IConfiguration
                Configuration
        )
        {
                
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            
            return services;
        }

    }
}
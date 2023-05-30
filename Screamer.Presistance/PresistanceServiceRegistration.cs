using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Screamer.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Screamer.Application.Contracts.Presistance;
using Screamer.Presistance.DatabaseContext;
using Screamer.Presistance.Repositories;
using Screamer.Presistance.Helpers;
using Algolia.Search;
using Algolia.Search.Clients;

namespace Screamer.Presistance
{
    public static class PresistanceServiceRegistration
    {
        public static IServiceCollection AddPresistanceServices(
            this IServiceCollection services,
            //config
            IConfiguration Configuration
        )
        {
            services.AddDbContext<ScreamerDbContext>(
                options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ScreamerDbConnection"))
            );
            services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ScreamerDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IAvatarRepository, AvatarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<IReactionRepository, ReactionRepository>();
            services.AddScoped<ICoverRepository, CoverRepository>();
            services.AddScoped<IPostImageRepository, PostImageRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<SearchClient>(
                provider =>
                    new SearchClient(
                        Configuration["Algolia:ApplicationId"],
                        Configuration["Algolia:APIKey"]
                    )
            );
            services.AddScoped<IAlgoliaService, AlgoliaService>();

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

            return services;
        }
    }
}

using EasyIND.Application.Common.Interfaces;
using EasyIND.Application.Services;
using EasyIND.Domain.Models;
using EasyIND.Infrastructure.Repositories;

namespace EasyIND.API.IoC
{
    public static class ApiRegistry
    {
        public static void AddApiRegistry(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddCors(x => x.AddPolicy("AllowAnyOrigin", x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
        }

        public static void GetConfigurationSections(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
    }
}

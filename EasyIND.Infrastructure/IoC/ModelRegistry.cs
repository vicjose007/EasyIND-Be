using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyIND.Infrastructure.Contexts.EasyIND;
using EasyIND.Infrastructure.UnitOfWorks;

namespace EasyIND.Infrastructure.IoC
{
    public static class ModelRegistry
    {
        public static void AddModelRegistry(this IServiceCollection services)
        {
            services.AddTransient<IEasyINDDbContext, EasyINDDbContext>();
            services.AddScoped<IUnitOfWork<IEasyINDDbContext>, EasyINDUnitOfWork>();

        }
    }
}
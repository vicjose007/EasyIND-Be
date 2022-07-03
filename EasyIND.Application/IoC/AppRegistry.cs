using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.IoC
{
    public static class BlRegistry
    {
        public static void AddAppRegistry(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
        }
    }
}


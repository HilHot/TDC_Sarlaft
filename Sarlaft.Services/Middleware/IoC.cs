using Microsoft.Extensions.DependencyInjection;
using Sarlaft.Core;
using Sarlaft.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sarlaft.Services.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IConsultarSarlaft, ConsultarSarlaft>();
            services.AddScoped<IUtil, Util>();

            return services;
        }
    }
}

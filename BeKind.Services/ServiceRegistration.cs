using BeKind.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeKind.Server
{
    public static class ServiceRegistration
    {
        public static void RegisterServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterInfrastructure(configuration);
        }
    }
}

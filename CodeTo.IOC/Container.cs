using CodeTo.DataEF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.IOC
{
     public static class Container
    {
        public static IServiceCollection AddIOCServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CodeToContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("CodeToConnection"));
            });



            return services;
        }
    }
}

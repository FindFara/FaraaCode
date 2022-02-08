using CodeTo.Core.Services.AccountService;
using CodeTo.Core.Services.AccountVm;
using CodeTo.Core.Utilities.Extension;
using CodeTo.Core.Utilities.Security;
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


            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IViewRenderService, RenderViewToString>();

            return services;
        }
    }
}

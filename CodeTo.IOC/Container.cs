using CodeTo.Core.Services.AccountServices;
using CodeTo.Core.Services.AdminPanelServices;
using CodeTo.Core.Services.UserPanelServices;
using CodeTo.Core.Utilities.Extensions;
using CodeTo.Core.Utilities.Other;
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
using CodeTo.Core.Services.ArticleServices;
using CodeTo.Core.Services.CourseServices;
using CodeTo.Core.Services.PermissionServices;


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

            services.AddSingleton(typeof(ILoggerService<>), typeof(LoggerService<>));
            services.AddTransient<IAccountService, AccountService>();
            services.AddSingleton<ISecurityService, SecurityService>();
            services.AddTransient<IViewRenderService, RenderViewToString>();
            services.AddTransient<IUserPanelService, UserPanelService>();
            services.AddTransient<IAdminPanelService, AdminPanelService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IArticleGroupService,ArticleGroupService>();
            services.AddTransient<ICourseGroupService,CourseGroupService>();


            return services;
        }
    }
}

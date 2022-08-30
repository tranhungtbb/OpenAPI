using DbContextHelper.ReadDbContext;
using DbContextHelper.WriteDbContext;
using Microsoft.Extensions.DependencyInjection;
namespace DbContextHelper
{
    public static class DbContextDependencyInjection
    {
        public static IServiceCollection UseDbContextHelperDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IAppSettings, AppSettings>();
            services.AddTransient<IAppReadDbContext, AppReadDbContext>();
            services.AddTransient<IAppWriteDbContext, AppWriteDbContext>();
            return services;
        }
    }
}

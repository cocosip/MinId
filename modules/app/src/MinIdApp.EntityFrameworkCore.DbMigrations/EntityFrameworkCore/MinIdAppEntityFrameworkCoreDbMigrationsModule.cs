using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Modularity;

namespace MinIdApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(MinIdAppEntityFrameworkCoreModule)
        )]
    public class MinIdAppEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            context.Services.AddAbpDbContext<MinIdAppMigrationsDbContext>();
        }
    }
}

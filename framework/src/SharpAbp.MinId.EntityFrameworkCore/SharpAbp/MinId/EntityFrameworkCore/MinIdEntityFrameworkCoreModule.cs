using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SharpAbp.MinId.EntityFrameworkCore
{
    [DependsOn(
        typeof(MinIdDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class MinIdEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MinIdDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                
                options.AddRepository<MinIdInfo, EfCoreMinIdInfoRepository>();
                options.AddDefaultRepositories(true);
            });
        }
    }
}
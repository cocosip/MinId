using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace SharpAbp.MinId
{
    [DependsOn(
        typeof(MinIdDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class MinIdApplicationContractsModule : AbpModule
    {

    }
}

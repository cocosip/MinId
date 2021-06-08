using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SharpAbp.MinId
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(MinIdDomainSharedModule)
    )]
    public class MinIdDomainModule : AbpModule
    {

    }
}

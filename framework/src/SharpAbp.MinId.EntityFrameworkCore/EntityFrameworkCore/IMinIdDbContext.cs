using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SharpAbp.MinId.EntityFrameworkCore
{
    [ConnectionStringName(MinIdDbProperties.ConnectionStringName)]
    public interface IMinIdDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}
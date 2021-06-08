using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SharpAbp.MinId.EntityFrameworkCore
{
    [ConnectionStringName(MinIdDbProperties.ConnectionStringName)]
    public class MinIdDbContext : AbpDbContext<MinIdDbContext>, IMinIdDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public MinIdDbContext(DbContextOptions<MinIdDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureMinId();
        }
    }
}
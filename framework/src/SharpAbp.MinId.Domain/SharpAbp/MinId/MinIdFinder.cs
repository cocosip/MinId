using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace SharpAbp.MinId
{
    public class MinIdFinder : IMinIdFinder, ITransientDependency
    {
        protected IMinIdInfoRepository MinIdInfoRepository { get; }
        public MinIdFinder(IMinIdInfoRepository minIdInfoRepository)
        {
            MinIdInfoRepository = minIdInfoRepository;
        }

        /// <summary>
        /// Check bizType minIdInfo exist
        /// </summary>
        /// <param name="bizType"></param>
        /// <returns></returns>
        public virtual async Task<bool> ExistAsync([NotNull] string bizType)
        {
            Check.NotNullOrWhiteSpace(bizType, nameof(bizType));
            var minIdInfo = await MinIdInfoRepository.FindByBizTypeAsync(bizType);
            return minIdInfo != null;
        }

    }
}

﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace SharpAbp.MinId
{
    public class SegmentIdService : ISegmentIdService, ITransientDependency
    {
        protected ILogger Logger { get; }
        protected MinIdOptions Options { get; }
        protected IUnitOfWorkManager UnitOfWorkManager { get; }
        protected IMinIdInfoRepository MinIdInfoRepository { get; }
        public SegmentIdService(
            ILogger<SegmentIdService> logger,
            IOptions<MinIdOptions> options,
            IUnitOfWorkManager unitOfWorkManager,
            IMinIdInfoRepository minIdInfoRepository)
        {
            Logger = logger;
            Options = options.Value;
            UnitOfWorkManager = unitOfWorkManager;
            MinIdInfoRepository = minIdInfoRepository;
        }

        /// <summary>
        /// Get next segmentId by bizType
        /// </summary>
        /// <param name="bizType"></param>
        /// <returns></returns>
        public virtual async Task<SegmentId> GetNextSegmentIdAsync(string bizType)
        {
            var retry = Options.ConflictRetryCount;
            var timeout = Options.TransactionTimeout;

            for (var i = 0; i < retry; i++)
            {
                SegmentId segmentId = null;

                try
                {
                    using (var uow = UnitOfWorkManager.Begin(true, true, IsolationLevel.ReadCommitted, timeout))
                    {
                        var minIdInfo = await MinIdInfoRepository.FindByBizTypeAsync(bizType);
                        if (minIdInfo == null)
                        {
                            throw new AbpException($"Can not find bizType '{bizType}'.");
                        }

                        //New id
                        var newId = minIdInfo.MaxId + minIdInfo.Step;

                        minIdInfo.UpdateMaxId(newId);
                        await MinIdInfoRepository.UpdateAsync(minIdInfo);
                        await uow.SaveChangesAsync();

                        segmentId = ConvertToSegmentId(minIdInfo);
                    }
                }
                catch (AbpDbConcurrencyException ex)
                {
                    Logger.LogError(ex, "Get next segmentId conflict. {0}", ex.Message);
                    segmentId = null;
                }

                if (segmentId != null)
                {
                    return segmentId;
                }
            }

            throw new AbpException("Get next segmentId conflict.");
        }

        protected virtual SegmentId ConvertToSegmentId(MinIdInfo minIdInfo)
        {
            var loadingPercent = Options.LoadingPercent;
            var segmentId = new SegmentId()
            {
                CurrentId = (minIdInfo.MaxId - minIdInfo.Step),
                MaxId = minIdInfo.MaxId,
                Remainder = minIdInfo.Remainder < 0 ? 0 : minIdInfo.Remainder,
                Delta = minIdInfo.Delta,
                LoadingId = minIdInfo.MaxId - minIdInfo.Step + minIdInfo.Step * (loadingPercent / 100)
            };

            return segmentId;
        }

    }
}

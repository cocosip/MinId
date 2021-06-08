using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SharpAbp.MinId
{
    public class MinIdToken : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Token
        /// </summary>
        public virtual string Token { get; set; }

        /// <summary>
        /// BizType
        /// </summary>
        public virtual string BizType { get; set; }

        /// <summary>
        /// Remark
        /// </summary>
        public virtual string Remark { get; set; }
    }
}

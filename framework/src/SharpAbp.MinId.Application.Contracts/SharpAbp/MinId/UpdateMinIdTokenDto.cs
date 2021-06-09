using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace SharpAbp.MinId
{
    public class UpdateMinIdTokenDto
    {
        /// <summary>
        /// BizType
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(MinIdTokenConsts), nameof(MinIdTokenConsts.MaxBizTypeLength))]
        public string BizType { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(MinIdTokenConsts), nameof(MinIdTokenConsts.MaxTokenLength))]
        public string Token { get; set; }

        [Required]
        [DynamicStringLength(typeof(MinIdTokenConsts), nameof(MinIdTokenConsts.MaxRemarkLength))]
        public string Remark { get; set; }
    }
}

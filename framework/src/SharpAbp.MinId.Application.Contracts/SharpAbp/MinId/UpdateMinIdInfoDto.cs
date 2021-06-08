using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace SharpAbp.MinId
{
    public class UpdateMinIdInfoDto : IValidatableObject
    {
        /// <summary>
        /// BizType
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(MinIdInfoConsts), nameof(MinIdInfoConsts.MaxBizTypeLength))]
        public string BizType { get; set; }

        /// <summary>
        /// MaxId
        /// </summary>
        [Required]
        public long MaxId { get; set; }

        /// <summary>
        /// Step
        /// </summary>
        [Required]
        public int Step { get; set; }

        /// <summary>
        /// Delta
        /// </summary>
        [Required]
        public int Delta { get; set; }

        /// <summary>
        /// Remainder
        /// </summary>
        [Required]
        public int Remainder { get; set; }

        [Required]
        public long Version { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Step <= 0)
            {
                yield return new ValidationResult($"Step should greater than 0.");
            }

            if (Delta < 0)
            {
                yield return new ValidationResult($"Delta should greater than 0.");
            }

            if (Version < 0)
            {
                yield return new ValidationResult($"Version should greater than 0.");
            }

            yield break;
        }
    }
}

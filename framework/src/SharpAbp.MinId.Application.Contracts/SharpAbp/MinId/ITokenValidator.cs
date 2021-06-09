using JetBrains.Annotations;
using System.Threading.Tasks;

namespace SharpAbp.MinId
{
    public interface ITokenValidator
    {
        /// <summary>
        /// Validate token
        /// </summary>
        /// <param name="bizType"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> ValidateAsync([NotNull] string bizType, [NotNull] string token);
    }
}

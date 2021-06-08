using Volo.Abp.Reflection;

namespace SharpAbp.MinId.Permissions
{
    public class MinIdPermissions
    {
        public const string GroupName = "MinId";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MinIdPermissions));
        }
    }
}
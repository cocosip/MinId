using SharpAbp.MinId.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SharpAbp.MinId.Permissions
{
    public class MinIdPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MinIdPermissions.GroupName, L("Permission:MinId"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MinIdResource>(name);
        }
    }
}
using Abp.Authorization;
using TrackingSystem.Authorization.Roles;
using TrackingSystem.Authorization.Users;

namespace TrackingSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

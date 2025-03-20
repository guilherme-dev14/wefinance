using Abp.Authorization;
using WeFinance.Authorization.Roles;
using WeFinance.Authorization.Users;

namespace WeFinance.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

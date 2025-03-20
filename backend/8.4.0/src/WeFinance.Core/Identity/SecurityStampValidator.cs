using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using WeFinance.Authorization.Roles;
using WeFinance.Authorization.Users;
using WeFinance.MultiTenancy;
using Microsoft.Extensions.Logging;
using Abp.Domain.Uow;
using WeFinance.Identity;
using WeFinance.MultiTenancy;

namespace WeFinance.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory,
            IUnitOfWorkManager unitOfWorkManager)
            : base(options, signInManager, systemClock, loggerFactory, unitOfWorkManager)
        {
        }
    }
}

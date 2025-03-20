using System.Threading.Tasks;
using Abp.Application.Services;
using WeFinance.Authorization.Accounts.Dto;

namespace WeFinance.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

using Abp.Application.Services;

namespace WeFinance
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class WeFinanceAppServiceBase : ApplicationService
    {
        protected WeFinanceAppServiceBase()
        {
            LocalizationSourceName = WeFinanceConsts.LocalizationSourceName;
        }
    }
}
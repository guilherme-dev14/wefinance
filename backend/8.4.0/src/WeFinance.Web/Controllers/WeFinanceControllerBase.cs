using Abp.AspNetCore.Mvc.Controllers;

namespace WeFinance.Web.Controllers
{
    public abstract class WeFinanceControllerBase: AbpController
    {
        protected WeFinanceControllerBase()
        {
            LocalizationSourceName = WeFinanceConsts.LocalizationSourceName;
        }
    }
}
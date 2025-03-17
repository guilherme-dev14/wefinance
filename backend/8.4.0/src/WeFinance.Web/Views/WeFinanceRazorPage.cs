using Abp.AspNetCore.Mvc.Views;

namespace WeFinance.Web.Views
{
    public abstract class WeFinanceRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected WeFinanceRazorPage()
        {
            LocalizationSourceName = WeFinanceConsts.LocalizationSourceName;
        }
    }
}

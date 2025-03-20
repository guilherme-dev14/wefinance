using Abp.Application.Navigation;
using Abp.Localization;

namespace WeFinance.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class WeFinanceNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
           
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WeFinanceConsts.LocalizationSourceName);
        }
    }
}

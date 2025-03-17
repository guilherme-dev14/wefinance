using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WeFinance.Configuration;
using WeFinance.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace WeFinance.Web.Startup
{
    [DependsOn(
        typeof(WeFinanceApplicationModule), 
        typeof(WeFinanceEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class WeFinanceWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public WeFinanceWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(WeFinanceConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<WeFinanceNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(WeFinanceApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WeFinanceWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(WeFinanceWebModule).Assembly);
        }
    }
}

using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WeFinance.Web.Startup;
namespace WeFinance.Web.Tests
{
    [DependsOn(
        typeof(WeFinanceWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class WeFinanceWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WeFinanceWebTestModule).GetAssembly());
        }
    }
}
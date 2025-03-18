using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WeFinance.EntityFrameworkCore; 

namespace WeFinance
{
    [DependsOn(
        typeof(WeFinanceCoreModule),
        typeof(AbpAutoMapperModule),
        typeof(WeFinanceEntityFrameworkCoreModule) 
    )]
    public class WeFinanceApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WeFinanceApplicationModule).GetAssembly());
        }
    }
}
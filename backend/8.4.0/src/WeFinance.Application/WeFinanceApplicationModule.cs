using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace WeFinance
{
    [DependsOn(
        typeof(WeFinanceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WeFinanceApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WeFinanceApplicationModule).GetAssembly());
        }
    }
}
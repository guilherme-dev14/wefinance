using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace WeFinance.EntityFrameworkCore
{
    [DependsOn(
        typeof(WeFinanceCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class WeFinanceEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WeFinanceEntityFrameworkCoreModule).GetAssembly());
        }
    }
}
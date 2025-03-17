using Abp.Modules;
using Abp.Reflection.Extensions;
using WeFinance.Localization;

namespace WeFinance
{
    public class WeFinanceCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            WeFinanceLocalizationConfigurer.Configure(Configuration.Localization);
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = WeFinanceConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WeFinanceCoreModule).GetAssembly());
        }
    }
}
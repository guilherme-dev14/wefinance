using System;
using System.Threading.Tasks;
using Abp.TestBase;
using WeFinance.EntityFrameworkCore;
using WeFinance.Tests.TestDatas;

namespace WeFinance.Tests
{
    public class WeFinanceTestBase : AbpIntegratedTestBase<WeFinanceTestModule>
    {
        public WeFinanceTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<WeFinanceDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<WeFinanceDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<WeFinanceDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<WeFinanceDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<WeFinanceDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<WeFinanceDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<WeFinanceDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<WeFinanceDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}

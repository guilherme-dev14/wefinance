using WeFinance.EntityFrameworkCore;

namespace WeFinance.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly WeFinanceDbContext _context;

        public TestDataBuilder(WeFinanceDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}
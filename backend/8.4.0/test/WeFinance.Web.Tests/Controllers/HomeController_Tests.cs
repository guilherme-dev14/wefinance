using System.Threading.Tasks;
using WeFinance.Web.Controllers;
using Shouldly;
using Xunit;

namespace WeFinance.Web.Tests.Controllers
{
    public class HomeController_Tests: WeFinanceWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
